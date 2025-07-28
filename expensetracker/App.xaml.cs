using Microsoft.Maui.Controls;

namespace expensetracker
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent(); // Must match what's defined in App.xaml
            MainPage = new MainPage();
        }
    }
}
