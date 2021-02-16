using CosmeticSalon.Common;
using System;
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

        public void addService(string name, int price)
        {
            db.addService(name, price);
        }

        public void addPost(string name, int salary)
        {
            db.addPost(name, salary);
        }

        public string[] getServicesStringList()
        {
            return db.getServicesStringList();
        }

        public void updateService(int id, int price)
        {
            db.updateService(id, price);
        }

        public void updatePost(int id, int salary)
        {
            db.updatePost(id, salary);
        }

        public int getServicePriceByID(int id)
        {
            return db.getServicePriceByID(id);
        }

        public int getPostSalaryByID(int id)
        {
            return db.getPostSalaryByID(id);
        }

        public string[] getClientsStringList(string search = null)
        {
            return db.getClientsStringList(search);
        }

        public void updateClients(Client client)
        {
            db.updateClients(client);
        }

        public Client getClientByID(int id)
        {
            return db.getClientByID(id);
        }

        public void deleteClientByID(int id)
        {
            db.deleteClientByID(id);
        }

        public bool tryToAddNewClient(Client client)
        {
            return db.tryToAddNewClient(client);
        }

        public string[] getStrListOfWorkers()
        {
            return db.getStrListOfWorkers();
        }

        public Client findFirstClient(string search)
        {
            return db.findFirstClient(search);
        }

        public void newOrder(int idWorker, int idClient, int idService, string description, int addPrice, DateTime dtStart, int durationMins)
        {
            db.newOrder(idWorker, idClient, idService, description, addPrice, dtStart, durationMins);
        }

        public int getClientIDByPhone(string phone)
        {
            return db.getClientIDByPhone(phone);
        }

        public Order[] getOrderForWorkerByDate(int workerID, DateTime dt)
        {
            return db.getOrderForWorkerByDate(workerID, dt);
        }
    }
}
