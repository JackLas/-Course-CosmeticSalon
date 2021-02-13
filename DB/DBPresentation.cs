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
    }
}
