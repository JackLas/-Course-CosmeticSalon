namespace CosmeticSalon.Common
{
    public class Account
    {
        public int ID { get; set; }
        public Types.AccountType Type { get; set; }

        public Account(Types.AccountType type)
        {
            Type = type;
        }
    }
}
