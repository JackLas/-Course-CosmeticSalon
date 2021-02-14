using System.Collections.Generic;

namespace CosmeticSalon.Common
{
    public class Employee
    {
        public int ID { set; get; }
        public string Surname { set; get; }
        public string Name { set; get; }
        public string MiddleName { set; get; }
        public string Post { set; get; }
        public int PostID { set; get; }
        public int SalaryBonus { set; get; }
        public string Phone { set; get; }
        public string[] Expirience { set; get; }
    }
}
