using CosmeticSalon.Common;

namespace CosmeticSalon.MainForms
{
    partial class FormWork
    {
        public partial class AccountantFormInitializer : IMainWindowInitializer
        {
            public void Initialize(FormWork form)
            {
                form.tabControl_main.SelectTab("tab_salary");
                form.initSalaryTab();
                form.initOtherTab();
                form.tabControl_main.TabPages.RemoveByKey("tab_schedule");
                form.tabControl_main.TabPages.RemoveByKey("tab_employees");
                form.tabControl_main.TabPages.RemoveByKey("tab_clients");
            }
        }
    }
}