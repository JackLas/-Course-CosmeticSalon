using CosmeticSalon.Common;

namespace CosmeticSalon.DB
{
    public class DBPresentation
    {
        private static DBPresentation mInstance;
        private PostgreSQLClient db;

        private DBPresentation()
        {
            db = new PostgreSQLClient();
        }

        static public DBPresentation instance()
        {
            if (mInstance == null)
            {
                mInstance = new DBPresentation();
            }
            return mInstance;
        }

        public Account login(string login, string password)
        {
            return db.login(login, password);
        }

        public void register(string login, string password, string surname, string name, string middleName, string phone, string[] exp)
        {
            db.register(login, password, surname, name, middleName, phone, exp);
        }

        public bool isLoginAlreadyExists(string login)
        {
            return db.isLoginAlreadyExists(login);
        }
    }
}
