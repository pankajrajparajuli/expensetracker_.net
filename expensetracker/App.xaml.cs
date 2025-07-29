using Microsoft.AspNetCore.Components.WebView.Maui;
using Microsoft.Maui.Controls;
using expensetracker;

namespace expensetracker
{
    public partial class App : Application
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
                        ComponentType = typeof(BlazorApp)
                    }
                }
                }
            };
        }
    }

}
