using System;
using System.Collections.Generic;
using System.Text;

namespace CosmeticSalon.Common
{
    public class Order
    {
        public int ID { set; get; }
        public string clientName { set; get; }
        public string serviceName { set; get; }
        public string desc { set; get; }
        public int fullPrice { set; get; }
        public DateTime dtStart { set; get; }
        public DateTime dtEnd { set; get; }

        public override string ToString()
        {
            string line = "[" + dtStart.TimeOfDay.ToString(@"hh\:mm") + "-" + dtEnd.TimeOfDay.ToString(@"hh\:mm") + "] " + 
                           serviceName + " - " + clientName;
            return line;
        }

        public string[] toRichText()
        {
            List<string> lines = new List<string>();

            lines.Add("Час: " + dtStart.TimeOfDay.ToString(@"hh\:mm") + " - " + dtEnd.TimeOfDay.ToString(@"hh\:mm"));
            lines.Add("Клієнт: " + clientName);
            lines.Add("Послуга: " + serviceName);
            if (desc != null && desc.Length > 0)
            {
                lines.Add("Замітки:");
                lines.Add(desc);
            }
            lines.Add("");
            lines.Add("До сплаты: " + fullPrice.ToString());

            return lines.ToArray();
        }

        public string toRichString()
        {
            StringBuilder str = new StringBuilder();
            foreach (var line in toRichText())
            {
                str.Append(line + "\n");
            }
            return str.ToString();
        }
    }
}
