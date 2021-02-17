using CosmeticSalon.DB;
using CosmeticSalon.Common;
using System.Windows.Forms;
using System;

namespace CosmeticSalon.MainForms
{
    partial class FormWork
    {
        public void initSalaryTab()
        {
            initSalaryEmployeesList();
            dateTimePicker1.Value = DateTime.Now.AddMonths(-1);
        }

        private void initSalaryEmployeesList()
        {
            lb_salary_employee.Items.Clear();
            foreach (string str in
                DBPresentation.instance().getStrListOfEmployees(
                    true,
                    tb_salary_search.Text.Length > 0 ? tb_salary_search.Text : null))
            {
                lb_salary_employee.Items.Add(str);
            }
        }

        private void btn_salary_search_Click(object sender, System.EventArgs e)
        {
            initSalaryEmployeesList();
        }

        private void dateTimePicker2_ValueChanged(object sender, System.EventArgs e)
        {
            if (dateTimePicker2.Value < dateTimePicker1.Value)
            {
                dateTimePicker2.Value = dateTimePicker1.Value;
            }
            if (dateTimePicker2.Value > DateTime.Now)
            {
                dateTimePicker2.Value = DateTime.Now;
            }
        }

        private void dateTimePicker1_ValueChanged(object sender, System.EventArgs e)
        {
            if (dateTimePicker1.Value > dateTimePicker2.Value)
            {
                dateTimePicker1.Value = dateTimePicker2.Value;
            }
            if (dateTimePicker1.Value > DateTime.Now)
            {
                dateTimePicker2.Value = DateTime.Now;
            }
        }

        private void btn_salary_count_Click(object sender, System.EventArgs e)
        {
            if (lb_salary_employee.SelectedIndex < 0)
            {
                MessageBox.Show("Оберіть працівника");
                return;
            }

            int workerID = 0;
            if (!Utils.getIDFromString(lb_salary_employee.SelectedItem.ToString(), out workerID))
            {
                return;
            }

            int salary = DBPresentation.instance().getFullSalaryByID(workerID);
            int companyIncome = DBPresentation.instance().getSalaryWorkingBonus(workerID, dateTimePicker1.Value, dateTimePicker2.Value);

            float pdfo_tax = 0.0f;
            if (!float.TryParse(tb_salary_tax_PDFO.Text, out pdfo_tax)) return;
            float vz_tax = 0.0f;
            if (!float.TryParse(tb_salary_tax_VZ.Text, out vz_tax)) return;

            rtb_salary_output.Text += "Базова заробітна плата: " + salary.ToString() + " грн\n";
            rtb_salary_output.Text += "Дохід салону: " + companyIncome.ToString() + " грн\n";
            rtb_salary_output.Text += "  - З яких бонус до заробітної плати (10%): " + (companyIncome / 10.0f).ToString() + " грн\n";
            rtb_salary_output.Text += "\n";
            float gross = salary + (companyIncome / 10.0f);
            rtb_salary_output.Text += "Заробітна плата до сплати податків (GROSS): " + gross.ToString() + " грн\n";
            float pdfo_value = gross * pdfo_tax / 100.0f;
            rtb_salary_output.Text += "Податок на доходи фізичних осіб (" + pdfo_tax.ToString() + "%): " + pdfo_value.ToString() + " грн\n";
            float vz_value = gross * vz_tax / 100.0f;
            rtb_salary_output.Text += "Війсковий збір (" + vz_tax.ToString() + "%): " + vz_value.ToString() + " грн\n";
            rtb_salary_output.Text += "\n";
            float net = gross - pdfo_value - vz_value;
            rtb_salary_output.Text += "Заробітна плата до виплати працівнику (NET): " + net.ToString() + " грн\n";
            //rtb_salary_output.Text = salary.ToString();

        }
    }
}