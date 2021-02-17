using CosmeticSalon.Common;

namespace CosmeticSalon.MainForms
{
    partial class FormWork
    {
        public partial class AdministratorFormInitializer : IMainWindowInitializer
        {
            public void Initialize(FormWork form)
            {
                form.tabControl_main.SelectTab("tab_employees");
                form.initEmployeesTab();
                form.initOtherTab();
                form.initClientsTab();
                form.initScheduleTab();
                form.initSalaryTab();
            }
        }
    }
}
