﻿using System;
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
                }

                employee.Close();
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
                    query.Parameters.AddWithValue("search", "%" + searchStr + "%");
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

        public Employee getEmployeeByID(int id)
        {
            Employee result = new Employee();

            var sql = @"SELECT ""Employees"".*, ""Posts"".name as ""post"" FROM ""Employees""
                        INNER JOIN ""Posts"" ON ""Employees"".id_post=""Posts"".id
                        WHERE ""Employees"".id=@id";

            using (var query = new NpgsqlCommand(sql, db))
            {
                query.Parameters.AddWithValue("id", id);
                var reader = query.ExecuteReader();
                if (reader.Read())
                {
                    result.ID = id;
                    result.Surname = (string)reader["surname"];
                    result.Name = (string)reader["name"];
                    result.MiddleName = (reader.IsDBNull(3) ? "" : (string)reader["middleName"]);
                    result.Post = (string)reader["post"];
                    result.PostID = (int)reader["id_post"];
                    result.Phone = (reader.IsDBNull(6) ? "" : (string)reader["phone"]);
                    result.Expirience = reader.IsDBNull(7) ? new string[0] : (string[])reader["exp"];
                }
                reader.Close();
            }

            return result;
        }

        public int getPostBaseSalaryByName(string postName)
        {
            int result = 0;
            string sql = @"SELECT ""Posts"".""baseSalary"" FROM ""Posts"" WHERE ""Posts"".name=@name";

            using (var query = new NpgsqlCommand(sql, db))
            {
                query.Parameters.AddWithValue("name", postName);
                var reader = query.ExecuteReader();

                if (reader.Read())
                {
                    result = (int)reader[0];
                }

                reader.Close();
            }

            return result;
        }

        public string[] getPostsStringList()
        {
            string sql = @"SELECT * FROM ""Posts"" ORDER BY id";
            using (var query = new NpgsqlCommand(sql, db))
            {
                List<string> rows = new List<string>();

                var reader = query.ExecuteReader();
                while (reader.Read())
                {
                    rows.Add( ((int)reader[0]).ToString()+": "+(string)reader[1] );
                }
                reader.Close();

                return rows.ToArray();
            }
        }

        public void aproveRegistration(int userID, int postID, int salaryBonus)
        {
            string sqlUpdateEmpl = @"
                UPDATE ""Employees"" 
                SET id_post=@postID, ""salaryBonus""=@bonus
                WHERE id=@id";
            using (var query = new NpgsqlCommand(sqlUpdateEmpl, db))
            {
                query.Parameters.AddWithValue("postID", postID);
                query.Parameters.AddWithValue("bonus", salaryBonus);
                query.Parameters.AddWithValue("id", userID);
                query.ExecuteNonQuery();
            }

            string sqlUpdateAcc = @"
                    UPDATE ""Accounts"" SET activated=@status 
                    WHERE id_employees=@id";
            using (var query = new NpgsqlCommand(sqlUpdateAcc, db))
            {
                query.Parameters.AddWithValue("status", true);
                query.Parameters.AddWithValue("id", userID);
                query.ExecuteNonQuery();
            }
        }

        public void cancelRegistration(int userID)
        {
            string delAccSql = @"DELETE FROM ""Accounts"" WHERE id_employees=@id";
            using (var query = new NpgsqlCommand(delAccSql, db))
            {
                query.Parameters.AddWithValue("id", userID);
                query.ExecuteNonQuery();
            }
            string delEmplSql = @"DELETE FROM ""Employees"" WHERE id=@id";
            using (var query = new NpgsqlCommand(delEmplSql, db))
            {
                query.Parameters.AddWithValue("id", userID);
                query.ExecuteNonQuery();
            }
        }

        public void updateEmployee(Employee empl)
        {
            string sql = @"
                UPDATE ""Employees"" SET surname=@surname,
                name=@name,
                ""middleName""=@middleName,
                id_post=@id_post,
                ""salaryBonus""=@salaryBonus,
                phone=@phone,
                exp=@exp
                WHERE id=@id";
            using (var query = new NpgsqlCommand(sql, db))
            {
                query.Parameters.AddWithValue("id", empl.ID);
                query.Parameters.AddWithValue("surname", empl.Surname);
                query.Parameters.AddWithValue("name", empl.Name);
                query.Parameters.AddWithValue("middleName", empl.MiddleName);
                query.Parameters.AddWithValue("id_post", empl.PostID);
                query.Parameters.AddWithValue("salaryBonus", empl.SalaryBonus);
                query.Parameters.AddWithValue("phone", empl.Phone);
                var expPar = new NpgsqlParameter("exp", NpgsqlTypes.NpgsqlDbType.Array | NpgsqlTypes.NpgsqlDbType.Text);
                expPar.Value = empl.Expirience;
                query.Parameters.Add(expPar);

                query.ExecuteNonQuery();
            }
        }

        public void addService(string name, int price)
        {
            string sql = @"INSERT INTO ""Services"" (""name"", ""price"") VALUES (@name, @price) ";
            using (var query = new NpgsqlCommand(sql, db))
            {
                query.Parameters.AddWithValue("name", name);
                query.Parameters.AddWithValue("price", price);

                query.ExecuteNonQuery();
            }
        }

        public void addPost(string name, int salary)
        {
            string sql = @"INSERT INTO ""Posts"" (""name"", ""baseSalary"") VALUES (@name, @salary) ";
            using (var query = new NpgsqlCommand(sql, db))
            {
                query.Parameters.AddWithValue("name", name);
                query.Parameters.AddWithValue("salary", salary);

                query.ExecuteNonQuery();
            }
        }

        public string[] getServicesStringList()
        {
            string sql = @"SELECT * FROM ""Services"" ORDER BY id";
            using (var query = new NpgsqlCommand(sql, db))
            {
                List<string> rows = new List<string>();

                var reader = query.ExecuteReader();
                while (reader.Read())
                {
                    rows.Add(((int)reader[0]).ToString() + ": " + (string)reader[1]);
                }
                reader.Close();

                return rows.ToArray();
            }
        }

        public void updateService(int id, int price)
        {
            string sql = @"UPDATE ""Services"" SET price=@price WHERE id=@id";

            using (var query = new NpgsqlCommand(sql, db))
            {
                query.Parameters.AddWithValue("price", price);
                query.Parameters.AddWithValue("id", id);

                query.ExecuteNonQuery();
            }
        }

        public void updatePost(int id, int salary)
        {
            string sql = @"UPDATE ""Posts"" SET ""baseSalary""=@salary WHERE id=@id";

            using (var query = new NpgsqlCommand(sql, db))
            {
                query.Parameters.AddWithValue("salary", salary);
                query.Parameters.AddWithValue("id", id);

                query.ExecuteNonQuery();
            }
        }

        public int getServicePriceByID(int id)
        {
            return getIntValueFromTableByID("Services", "price", id);
        }

        public int getPostSalaryByID(int id)
        {
            return getIntValueFromTableByID("Posts", "baseSalary", id);
        }

        private int getIntValueFromTableByID(string table, string value, int id)
        {
            int result = 0;
            string sql = "SELECT " + "\"" + value + "\" " + "FROM " + "\"" + table + "\" WHERE id=@id";
            using (var query = new NpgsqlCommand(sql, db))
            {
                query.Parameters.AddWithValue("id", id);

                var reader = query.ExecuteReader();

                if (reader.Read())
                {
                    result = (int)reader[0];
                }
                reader.Close();
            }
            return result;
        }

        public string[] getClientsStringList(string search)
        {
            int id = 0;
            string sql = @"SELECT * FROM ""Clients""";
            if (search != null)
            {
                sql += " WHERE ";

                if (int.TryParse(search, out id))
                {
                    sql += @" id=@search OR phone LIKE @phoneSearch";
                }
                else
                {
                    id = -1;
                    sql += @" ""fullName"" LIKE @search OR ""phone"" LIKE @search";
                }
            }
            sql += " ORDER BY id";

            using (var query = new NpgsqlCommand(sql, db))
            {
                if (search != null)
                {
                    if (id >= 0)
                    {
                        query.Parameters.AddWithValue("search", id);
                        query.Parameters.AddWithValue("phoneSearch", "%" + search + "%");
                    }
                    else query.Parameters.AddWithValue("search", "%" + search + "%");
                }

                var reader = query.ExecuteReader();
                List<string> rows = new List<string>();
                while (reader.Read())
                {
                    rows.Add(((int)reader[0]).ToString() + ": " + (string)reader[1] + ", " + (string)reader[2]);
                }
                reader.Close();

                return rows.ToArray();
            }
        }

        public void updateClients(Client client)
        {
            string sql = @"UPDATE ""Clients"" SET ""fullName""=@name, phone=@phone WHERE id=@id";
            using (var query = new NpgsqlCommand(sql, db))
            {
                query.Parameters.AddWithValue("name", client.FullName);
                query.Parameters.AddWithValue("phone", client.Phone);
                query.Parameters.AddWithValue("id", client.ID);
                query.ExecuteNonQuery();
            }
        }

        public Client getClientByID(int id)
        {
            Client client = new Client();
            string sql = @"SELECT * FROM ""Clients"" WHERE id=@id";
            using (var query = new NpgsqlCommand(sql, db))
            {
                query.Parameters.AddWithValue("id", id);
                var reader = query.ExecuteReader();
                if (reader.Read())
                {
                    client.ID = (int)reader[0];
                    client.FullName = (string)reader[1];
                    client.Phone = (string)reader[2];
                }
                reader.Close();
                return client;
            }
        }

        public void deleteClientByID(int id)
        {
            string sql = @"DELETE FROM ""Clients"" WHERE id=@id";
            using (var query = new NpgsqlCommand(sql, db))
            {
                query.Parameters.AddWithValue("id", id);
                query.ExecuteNonQuery();
            }
        }

        public bool tryToAddNewClient(Client client)
        {
            bool isAlreadyExists = false;
            string checkPhoneSql = @"SELECT COUNT(*) FROM ""Clients"" WHERE phone=@phone";
            using (var query = new NpgsqlCommand(checkPhoneSql, db))
            {
                query.Parameters.AddWithValue("phone", client.Phone);
                var reader = query.ExecuteReader();
                if (reader.Read())
                {
                    isAlreadyExists = (long)reader[0] > 0;
                }
                reader.Close();
                if (isAlreadyExists) return false;
            }
            string updateSql = @"INSERT INTO ""Clients"" (""fullName"", phone) VALUES (@name, @phone)";
            using (var query = new NpgsqlCommand(updateSql, db))
            {
                query.Parameters.AddWithValue("name", client.FullName);
                query.Parameters.AddWithValue("phone", client.Phone);
                query.ExecuteNonQuery();
                return true;
            }
        }

        public string[] getStrListOfWorkers()
        {
            string sql = @"SELECT ""Employees"".id, ""Employees"".surname, ""Employees"".name, ""Posts"".name 
                           FROM ""Employees"" INNER JOIN ""Posts"" ON ""Posts"".id=""Employees"".id_post
                           WHERE id_post<>0 AND id_post<>2 AND id_post<>4
                           ORDER BY id";

            using (var query = new NpgsqlCommand(sql, db))
            {
                List<string> rows = new List<string>();
                var reader = query.ExecuteReader();

                while (reader.Read())
                {
                    rows.Add(
                        ((int)reader[0]).ToString() + ": " + 
                        (string)reader[1] + " " + (string)reader[2] + ", " + (string)reader[3]);
                }

                reader.Close();

                return rows.ToArray();
            }
        }

        public Client findFirstClient(string search)
        {
            int id = 0;
            string sql = @"SELECT * FROM ""Clients""";
            if (search != null)
            {
                sql += " WHERE ";

                if (int.TryParse(search, out id))
                {
                    sql += @" id=@search OR phone LIKE @phoneSearch";
                }
                else
                {
                    id = -1;
                    sql += @" ""fullName"" LIKE @search OR ""phone"" LIKE @search";
                }
            }

            using (var query = new NpgsqlCommand(sql, db))
            {
                if (search != null)
                {
                    if (id >= 0)
                    {
                        query.Parameters.AddWithValue("search", id);
                        query.Parameters.AddWithValue("phoneSearch", "%" + search + "%");
                    }
                    else query.Parameters.AddWithValue("search", "%" + search + "%");
                }

                var reader = query.ExecuteReader();
                Client client = null;
                if (reader.Read())
                {
                    client = new Client();

                    client.ID = (int)reader[0];
                    client.FullName = (string)reader[1];
                    client.Phone = (string)reader[2];
                }
                reader.Close();

                return client;
            }
        }

        public void newOrder(int idWorker, int idClient, int idService, string description, int addPrice, DateTime dtStart, int durationMins)
        {
            string sql = @"INSERT INTO ""Orders"" 
                         (id_worker, id_client, id_service, description, ""addPrice"", ""dateStart"", duration)
                         VALUES (@idWorker, @idClient, @idService, @description, @addPrice, @dtStart, @duration)";

            using (var query = new NpgsqlCommand(sql, db))
            {
                query.Parameters.AddWithValue("idWorker", idWorker);
                query.Parameters.AddWithValue("idClient", idClient);
                query.Parameters.AddWithValue("idService", idService);
                query.Parameters.AddWithValue("description", description);
                query.Parameters.AddWithValue("addPrice", addPrice);
                query.Parameters.AddWithValue("dtStart", dtStart);
                query.Parameters.AddWithValue("duration", durationMins);

                query.ExecuteNonQuery();
            }
        }

        public int getClientIDByPhone(string phone)
        {
            string sql = @"SELECT id FROM ""Clients"" WHERE phone=@phone";

            using (var query = new NpgsqlCommand(sql, db))
            {
                query.Parameters.AddWithValue("phone", phone);

                var reader = query.ExecuteReader();
                int id = -1;
                if (reader.Read())
                {
                    id = (int)reader[0];
                }

                reader.Close();
                return id;
            }
        }

        public Order[] getOrderForWorkerByDate(int workerID, DateTime dt)
        {
            string sql = @"
                SELECT ""Clients"".""fullName"", ""Services"".name, ""Services"".price, ""Orders"".""addPrice"", 
                ""Orders"".""dateStart"", ""Orders"".duration, ""Orders"".description
                FROM ""Orders""
                INNER JOIN ""Clients"" ON ""Orders"".id_client = ""Clients"".id
                INNER JOIN ""Services"" ON ""Orders"".id_service = ""Services"".id
                WHERE ""Orders"".id_worker=@worker AND ""Orders"".""dateStart"">@dayStart AND ""Orders"".""dateStart""<@dayEnd
                ORDER BY ""Orders"".""dateStart""";

            using (var query = new NpgsqlCommand(sql, db))
            {
                query.Parameters.AddWithValue("worker", workerID);
                DateTime dayStart = new DateTime(dt.Year, dt.Month, dt.Day, 0, 0, 0);
                DateTime dayEnd = dayStart.AddDays(1);
                query.Parameters.AddWithValue("dayStart", dayStart);
                query.Parameters.AddWithValue("dayEnd", dayEnd);

                List<Order> rows = new List<Order>();
                var reader = query.ExecuteReader();
                while (reader.Read())
                {
                    Order order = new Order();

                    order.clientName = (string)reader[0];
                    order.serviceName = (string)reader[1];
                    order.fullPrice = (int)reader[2] + (int)reader[3];

                    DateTime readOrderStart = (DateTime)reader[4];
                    int duration = (int)reader[5];
                    order.dtStart = readOrderStart;
                    order.dtEnd = readOrderStart.AddMinutes(duration);
                    order.desc = (string)reader[6];

                    rows.Add(order);
                }
                reader.Close();
                return rows.ToArray();
            }
        }

        public int getFullSalaryByID(int workerID)
        {
            string sql = @"SELECT ""Employees"".""salaryBonus"", ""Posts"".""baseSalary""
            FROM ""Employees"" INNER JOIN ""Posts"" ON ""Employees"".id_post=""Posts"".id
            WHERE ""Employees"".id=@id
            ";

            using (var query = new NpgsqlCommand(sql, db))
            {
                query.Parameters.AddWithValue("id", workerID);

                var reader = query.ExecuteReader();
                int result = 0;
                if  (reader.Read())
                {
                    result = (int)reader[0] + (int)reader[1];
                }
                reader.Close();
                return result;
            }
        }

        public int getSalaryWorkingBonus(int workerID, DateTime begin, DateTime end)
        {
            string sql = @"SELECT ""Orders"".""addPrice"", ""Services"".price 
            FROM ""Orders"" INNER JOIN ""Services"" ON ""Orders"".id_service=""Services"".id 
            WHERE ""Orders"".id_worker=@id
            AND ""Orders"".""dateStart"">=@dt_start AND ""Orders"".""dateStart""<=@dt_end ";

            using (var query = new NpgsqlCommand(sql, db))
            {
                query.Parameters.AddWithValue("id", workerID);
                query.Parameters.AddWithValue("dt_start", begin.Date);
                query.Parameters.AddWithValue("dt_end", end.Date);

                var reader = query.ExecuteReader();
                int result = 0;

                while (reader.Read())
                {
                    result += (int)reader[0] + (int)reader[1];
                }

                reader.Close();
                return result;
            }
        }
    }
}
