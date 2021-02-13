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
            UNKNOWN = 0,
            NOT_ACTIVE,
            WORKER,
            ACOUNTANT,
            ADMINISTRATOR
        }
    }
}
