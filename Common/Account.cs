using CosmeticSalon.MainForms;

namespace CosmeticSalon.Common
{
    public class Account
    {
        public int ID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public string Phone { get; set; }
        public int SalaryBonus { get; set; }
        public string[] Expirience { get; set; }
        public Types.AccountType Type { get; set; }

        private IMainWindowInitializer mInitializer;

        public Account(Types.AccountType type)
        {
            setAccountType(type);
        }

        public void initializeForm(FormWork form)
        {
            if (mInitializer != null)
            {
                mInitializer.Initialize(form);
            }
        }

        public void setAccountType(Types.AccountType type)
        {
            this.Type = type;
            switch (type)
            {
                case Types.AccountType.NOT_ACTIVE:
                case Types.AccountType.UNKNOWN:
                    mInitializer = null;
                    break;
                case Types.AccountType.ADMINISTRATOR:
                    mInitializer = new FormWork.AdministratorFormInitializer();
                    break;
                case Types.AccountType.ACCOUNTANT:
                    mInitializer = new FormWork.AccountantFormInitializer();
                    break;
                default:
                    mInitializer = new FormWork.WorkerFormInitializer();
                    break;
            }
        }
    }
}
