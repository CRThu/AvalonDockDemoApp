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

        public MenuViewsViewModel(IEnumerable<string> dockViewNames) : this()
        {
            Header = "Views";

            foreach (var dockViewName in dockViewNames)
            {
                Items.Add(GetMenuItemViewModel(dockViewName));
            }

            Separator separator= new Separator();
        }

        private MenuItemBaseViewModel GetMenuItemViewModel(string dockViewName)
        {
            var menuItemViewModel = new MenuViewItemViewModel();
            menuItemViewModel.IsCheckable = false;
            menuItemViewModel.IsChecked = false;
            menuItemViewModel.Header = dockViewName;

            return menuItemViewModel;
        }
    }
}
