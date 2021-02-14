using CosmeticSalon.Common;

namespace CosmeticSalon.MainForms
{
    partial class FormWork
    {
        public partial class AdministratorFormInitializer : IMainWindowInitializer
        {
            public void Initialize(FormWork form)
            {
                form.Text = "Hello from Admin";
                //form.lbl_test.Text = "Hello from Admin";
            }
        }
    }
}
