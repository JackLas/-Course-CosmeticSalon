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
                @"SELECT ""Employees"".id as ""id"", 
                ""Accounts"".activated as ""status"", 
                ""Employees"".id_post as ""post""
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
                        acc.Type = Utils.accountTypeFromDBID((int)employee["post"]);
                    }
                    else
                    {
                        acc.Type = Types.AccountType.NOT_ACTIVE;
                    }
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
                string expSqlArray = "{";
                bool isSqlArraySet = false;
                foreach (string line in exp)
                {
                    if (isSqlArraySet) expSqlArray += ",";

                    expSqlArray += "{" + line +"}";
                    isSqlArraySet = true;
                }
                expSqlArray += "}";


                addEmployeeQuery.Parameters.AddWithValue("surname", surname);
                addEmployeeQuery.Parameters.AddWithValue("name", name);
                addEmployeeQuery.Parameters.AddWithValue("middleName", middleName);
                addEmployeeQuery.Parameters.AddWithValue("phone", phone);

                var expPar = new NpgsqlParameter("exp", NpgsqlTypes.NpgsqlDbType.Array | NpgsqlTypes.NpgsqlDbType.Text);
                expPar.Value = exp;
                addEmployeeQuery.Parameters.Add(expPar);

                //addEmployeeQuery.Parameters.AddWithValue("exp", expSqlArray);

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
    }
}
