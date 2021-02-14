using CosmeticSalon.Common;
using System.Collections.Generic;

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

        public string getPostName(Types.AccountType type)
        {
            return db.getPostName(type);
        }

        public List<string> getStrListOfEmployees(bool activatedAccounts = false, string searchStr = null)
        {
            return db.getStrListOfEmployees(activatedAccounts, searchStr);
        }

        public Employee getEmployeeByID(int id)
        {
            return db.getEmployeeByID(id);
        }

        public int getPostBaseSalaryByName(string postName)
        {
            return db.getPostBaseSalaryByName(postName);
        }

        public string[] getPostsStringList()
        {
            return db.getPostsStringList();
        }

        public void aproveRegistration(int userID, int postID, int salaryBonus)
        {
            db.aproveRegistration(userID, postID, salaryBonus);
        }

        public void cancelRegistration(int userID)
        {
            db.cancelRegistration(userID);
        }

        public void updateEmployee(Employee empl)
        {
            db.updateEmployee(empl);
        }
    }
}
