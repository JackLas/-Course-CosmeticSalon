using System;
using Npgsql;
using CosmeticSalon.Common;
using System.Collections.Generic;

namespace CosmeticSalon.DB
{
    class PostgreSQLClient : IDisposable
    {
        private string connString;
        NpgsqlConnection db;

        public PostgreSQLClient()
        {
            connString = "Host=localhost;" +
                         "Username=postgres;" +
                         "Password=admin;" +
                         "Database=salon;";
                       //"Application Name=NAME;";

            db = new NpgsqlConnection(connString);
            db.Open();
        }

        public void Dispose()
        {
            db.Close();
        }

        public Account login(string login, string password)
        {
            string sql =
                @"SELECT ""Employees"".id, 
                ""Employees"".surname,
                ""Employees"".name,
                ""Employees"".""middleName"",
                ""Employees"".id_post as ""post"",
                ""Employees"".phone,
                ""Employees"".""salaryBonus"",
                ""Employees"".exp,
                ""Accounts"".activated as ""status"" 
                FROM ""Employees""
                INNER JOIN ""Accounts"" ON ""Accounts"".id_employees=""Employees"".id
                WHERE ""Accounts"".login=@login AND ""Accounts"".password=@password";

            using (var query = new NpgsqlCommand(sql, db))
            {
                query.Parameters.AddWithValue("login", login);
                query.Parameters.AddWithValue("password", Utils.toMD5(password));

                Account acc = new Account(Types.AccountType.UNKNOWN);

                var employee = query.ExecuteReader();

                if (employee.Read())
                {
                    acc.ID = (int)employee["id"];

                    if ((bool)employee["status"])
                    {
                        acc.setAccountType(Utils.accountTypeFromDBID((int)employee["post"]));
                    }
                    else
                    {
                        acc.setAccountType(Types.AccountType.NOT_ACTIVE);
                    }

                    acc.Surname = (string)employee["surname"];
                    acc.Name = (string)employee["name"];
                    acc.MiddleName = employee.IsDBNull(3) ? "" : (string)employee["middleName"];
                    acc.Phone = employee.IsDBNull(5) ? "" : (string)employee["phone"];
                    acc.SalaryBonus = (int)employee["salaryBonus"];
                    acc.Expirience = employee.IsDBNull(7) ? new string[0] : (string[])employee["exp"];

                    employee.Close();
                }

                return acc;
            }
        }

        public int getEmployeeID(string surname, string name, string middleName, string phone)
        {
            int result = -1;

            string sql = @"SELECT ""id"" FROM ""Employees""";

            bool isSet = false;
            if (surname != null && surname.Length > 0)
            {
                if (isSet) sql += @" AND "; else sql += @" WHERE ";
                sql += @" ""surname""="+"'"+surname+"'";
                isSet = true;
            }
            if (name != null && name.Length > 0)
            {
                if (isSet) sql += @" AND "; else sql += @" WHERE ";
                sql += @" ""name""=" + "'" + name + "'";
                isSet = true;
            }
            if (middleName != null && middleName.Length > 0)
            {
                if (isSet) sql += @" AND "; else sql += @" WHERE ";
                sql += @" ""middleName""=" + "'" + middleName + "'";
                isSet = true;
            }
            if (middleName != null && middleName.Length > 0)
            {
                if (isSet) sql += @" AND "; else sql += @" WHERE ";
                sql += @" ""phone""=" + "'" + phone + "'";
                isSet = true;
            }
            using (var query = new NpgsqlCommand(sql, db))
            {
                if (isSet)
                {
                    var employee = query.ExecuteReader();
                    if (employee.Read())
                    {
                        result = (int)employee["id"];
                    }
                    employee.Close();
                }
            }

            return result;
        }

        public bool isLoginAlreadyExists(string login)
        {
            bool result = false;
            string sql = @"SELECT COUNT(*) FROM ""Accounts"" WHERE ""login""=@login";
            using (var query = new NpgsqlCommand(sql, db))
            {
                query.Parameters.AddWithValue("login", login);
                var count = query.ExecuteReader();
                if (count.Read())
                {
                    result = ((long)count["count"] > 0);
                }
                count.Close();
            }
            return result;
        }

        public void register(string login, string password, string surname, string name, string middleName, string phone, string[] exp)
        {
            string addEmployeeSql =
                @"
                INSERT INTO ""Employees""
                    (""surname"", 
                     ""name"",
                     ""middleName"",
                     ""phone"",
                     ""exp"")
                VALUES (@surname, @name, @middleName, @phone, @exp)
                ";

            using (var addEmployeeQuery = new NpgsqlCommand(addEmployeeSql, db))
            {
                addEmployeeQuery.Parameters.AddWithValue("surname", surname);
                addEmployeeQuery.Parameters.AddWithValue("name", name);
                addEmployeeQuery.Parameters.AddWithValue("middleName", middleName);
                addEmployeeQuery.Parameters.AddWithValue("phone", phone);

                var expPar = new NpgsqlParameter("exp", NpgsqlTypes.NpgsqlDbType.Array | NpgsqlTypes.NpgsqlDbType.Text);
                expPar.Value = exp;
                addEmployeeQuery.Parameters.Add(expPar);

                addEmployeeQuery.ExecuteNonQuery();
            }

            string addAccountSql =
                @"
                INSERT INTO ""Accounts"" (""login"", ""password"", ""id_employees"")
                VALUES (@login, @password, @id_employees)
                ";
            using (var addAccountQuery = new NpgsqlCommand(addAccountSql, db))
            {
                addAccountQuery.Parameters.AddWithValue("login", login);
                addAccountQuery.Parameters.AddWithValue("password", Utils.toMD5(password));
                int id = getEmployeeID(surname, name, middleName, phone);
                addAccountQuery.Parameters.AddWithValue("id_employees", id);

                addAccountQuery.ExecuteNonQuery();
            }
        }

        public string getPostName(Types.AccountType type)
        {
            string result = "[UNKNOWN]";
            string sql = @"SELECT ""name"" FROM ""Posts"" WHERE ""id""=@typeid";
            using (var query = new NpgsqlCommand(sql, db))
            {
                query.Parameters.AddWithValue("typeid", (int)type);
                var reader = query.ExecuteReader();
                if (reader.Read())
                {
                    result = reader.GetString(0);
                }
                reader.Close();
            }
            return result;
        }

        public List<string> getStrListOfEmployees(bool activatedAccounts, string searchStr)
        {
            List<string> result = new List<string>();
            string sql =
                @"SELECT ""Employees"".id, surname, name, ""middleName""
                FROM ""Employees""
                INNER JOIN ""Accounts"" ON ""Accounts"".id_employees=""Employees"".id
                WHERE ""Accounts"".activated=@activated ";

            if (searchStr != null)
            {
                sql += " AND ";
                int parseOut = 0;
                if (int.TryParse(searchStr, out parseOut))
                {
                    sql += @" ""Employees"".id=@id ";
                }
                else
                {
                    sql += @" surname LIKE @search OR name LIKE @search OR ""middleName"" LIKE @search ";
                }
            }
            sql += @" ORDER BY ""Employees"".id ";

            using (var query = new NpgsqlCommand(sql, db))
            {
                query.Parameters.AddWithValue("activated", activatedAccounts);
                int parseOut = 0;
                if (int.TryParse(searchStr, out parseOut))
                {
                    query.Parameters.AddWithValue("id", parseOut);
                }
                else if (searchStr != null)
                {
                    //var par = new NpgsqlParameter()
                    query.Parameters.AddWithValue("search", "%"+searchStr+"%");
                }


                var reader = query.ExecuteReader();

                while (reader.Read())
                {
                    string emplStr =
                        ((int)reader["id"]).ToString() + ": " +
                        (string)reader["Surname"] + " " +
                        (string)reader["name"] + " " +
                        (reader.IsDBNull(3) ? "" : (string)reader["middleName"]);
                    result.Add(emplStr);
                }

                reader.Close();
            }

            return result;
        }
    }
}
