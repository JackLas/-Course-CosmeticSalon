using CosmeticSalon.Common;

namespace CosmeticSalon.MainForms
{
    partial class FormWork
    {
        public partial class WorkerFormInitializer : IMainWindowInitializer
        {
            public void Initialize(FormWork form)
            {
                form.tabControl_main.SelectTab("tab_schedule");
                form.initScheduleTab();
                form.initClientsTab();
                form.tabControl_main.TabPages.RemoveByKey("tab_other");
                form.tabControl_main.TabPages.RemoveByKey("tab_employees");
                form.tabControl_main.TabPages.RemoveByKey("tab_salary");
            }
        }
    }
}