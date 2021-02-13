using System;
using Npgsql;
using CosmeticSalon.Common;

namespace CosmeticSalon.DB
{
    class PostgreSQLClient : IDisposable
    {
        private String connString = "Host=localhost;Username=postgres;Password=admin;Database=salon;";
        NpgsqlConnection db;

        public PostgreSQLClient()
        {
            //db = new NpgsqlConnection(connString + "Application Name=" + this.Text);
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

        void register()
    }
}
