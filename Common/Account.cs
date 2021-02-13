namespace CosmeticSalon.Common
{
    public class Account
    {
        public int ID { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string MiddleName { get; set; }
        public Types.AccountType Type { get; set; }
        public string Phone { get; set; }
        public int SalaryBonus { get; set; }
        public string[] Expirience { get; set; }

        public Account(Types.AccountType type)
        {
            Type = type;
        }
    }
}
