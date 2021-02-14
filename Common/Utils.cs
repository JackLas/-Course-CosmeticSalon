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

        static public bool getIDFromString(string str, out int value)
        {
            return int.TryParse(str.Substring(0, str.IndexOf(":")), out value);
        }

        static public string getIDBodyFromString(string str)
        {
            int deviderIdx = str.IndexOf(":");
            if (deviderIdx + 1 != str.Length - 1)
            {
                return str.Substring(deviderIdx+1, str.Length-deviderIdx-1).Trim();
            }
            return "";
            
        }
    }
}
