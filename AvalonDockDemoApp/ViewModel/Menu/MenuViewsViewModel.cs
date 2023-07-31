using AvalonDockDemoApp.ViewModel.Message;
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
    public partial class MenuViewsViewModel : MenuItemBaseViewModel
    {
        public MenuViewsViewModel()
        {
        }

        public MenuViewsViewModel(IDictionary<string, DockViewWindowType> dockViewNames) : this()
        {
            Header = "Views";

            foreach (var dockViewName in dockViewNames)
            {
                Items.Add(GetMenuItemViewModel(dockViewName.Key, dockViewName.Value));
            }

            Separator separator = new Separator();
        }

        private MenuItemBaseViewModel GetMenuItemViewModel(string dockViewName, DockViewWindowType type)
        {
            var menuItemViewModel = new MenuViewItemViewModel();
            menuItemViewModel.IsCheckable = false;
            menuItemViewModel.IsChecked = false;
            menuItemViewModel.Header = dockViewName;
            menuItemViewModel.WindowType = type;

            return menuItemViewModel;
        }
    }
}
