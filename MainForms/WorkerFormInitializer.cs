using CosmeticSalon.Common;

namespace CosmeticSalon.MainForms
{
    partial class FormWork
    {
        public partial class WorkerFormInitializer : IMainWindowInitializer
        {
            public void Initialize(FormWork form)
            {
                form.Text = "Hello from Worker";
                form.lbl_test.Text = "Hello from Worker";
            }
        }
    }
}