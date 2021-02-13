using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CosmeticSalon.Common
{
    public class Types
    {
        public enum AccountType
        {
            NOT_ACTIVE = -1,
            UNKNOWN = 0,
            HAIRDRESSER = 1,
            ADMINISTRATOR = 2,
            Masseur = 3
        }
    }
}
