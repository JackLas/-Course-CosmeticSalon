using System.Text;

namespace CosmeticSalon.Common
{
    public class Utils
    {
        static public string toMD5(string str)
        {
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(str);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        static public Types.AccountType accountTypeFromDBID(int id)
        {
            /*
            switch (id)
            {
                case 2:
                    return Types.AccountType.ADMINISTRATOR;
                default:
                    return Types.AccountType.UNKNOWN;
            }
            */

            return (Types.AccountType)id;
        }
    }
}
