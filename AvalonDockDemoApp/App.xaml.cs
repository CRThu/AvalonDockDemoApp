using AvalonDockDemoApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace AvalonDockDemoApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //public new static App Current => (App)Application.Current;
        //public static ViewModel.ViewModelLocator Locator { get; set; } = new();
        public static ViewModelLocator Locator => (ViewModelLocator)App.Current.Resources["Locator"];
    }
}
