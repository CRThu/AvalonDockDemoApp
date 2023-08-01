using AvalonDockDemoApp.ViewModel.Message;
using AvalonDockDemoApp.ViewModel.Dock;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AvalonDockDemoApp.ViewModel.Menu
{
    public partial class MenuThemesViewModel : MenuItemBaseViewModel
    {
        public MenuThemesViewModel()
        {
        }

        public MenuThemesViewModel(IEnumerable<string> themeNames) : this()
        {
            Header = "Themes";

            foreach (var themeName in themeNames)
            {
                Items.Add(GetThemeItemViewModel(themeName));
            }

            //Separator separator = new Separator();
            //Items.Add(separator);
        }

        private MenuThemeItemViewModel GetThemeItemViewModel(string themeName)
        {
            var themeItemViewModel = new MenuThemeItemViewModel();
            themeItemViewModel.IsCheckable = false;
            themeItemViewModel.IsChecked = false;
            themeItemViewModel.Header = themeName;

            return themeItemViewModel;
        }
    }
}
