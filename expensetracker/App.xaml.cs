using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Maui.Controls;
using expensetracker;

namespace expensetracker
{
    public partial class App : Application // Ensure this matches the base class of all other partial declarations of 'App'  
    {
        public App()
        {
            InitializeComponent();

            MainPage = new ContentPage
            {
                Content = new BlazorWebView
                {
                    HostPage = "wwwroot/index.html",
                    RootComponents =
                       {
                           new RootComponent
                           {
                               Selector = "#app",
                               ComponentType = typeof(BlazorApp) // This points to App.razor  
                           }
                       }
                }
            };
        }
    }
}
