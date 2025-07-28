using Microsoft.Maui.Controls;

namespace expensetracker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            // ✅ FIX: Create an instance of MainPage
            MainPage = new MainPage(); // or a navigation page or shell if you're using that
        }
    }
}
