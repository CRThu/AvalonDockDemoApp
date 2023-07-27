using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalonDockDemoApp.ViewModel.Menu
{
    public partial class MenuViewsViewModel : MenuItemViewModel
    {
        public MenuViewsViewModel()
        {
        }

        public MenuViewsViewModel(IEnumerable<DockWindowViewModel> dockWindows) : this()
        {
            Header = "Views";

            foreach (var dockWindow in dockWindows)
            {
                Items.Add(GetMenuItemViewModel(dockWindow));
            }
        }

        private MenuItemViewModel GetMenuItemViewModel(DockWindowViewModel dockWindowViewModel)
        {
            var menuItemViewModel = new MenuViewItemViewModel();
            menuItemViewModel.IsCheckable = true;

            menuItemViewModel.Header = dockWindowViewModel.Title;
            menuItemViewModel.IsChecked = !dockWindowViewModel.IsClosed;

            // 状态双向绑定

            /*
            dockWindowViewModel.PropertyChanged += (o, e) =>
            {
                if (e.PropertyName == nameof(DockWindowViewModel.IsClosed))
                    menuItemViewModel.IsChecked = !dockWindowViewModel.IsClosed;
            };

            menuItemViewModel.PropertyChanged += (o, e) =>
            {
                if (e.PropertyName == nameof(MenuItemViewModel.IsChecked))
                    dockWindowViewModel.IsClosed = !menuItemViewModel.IsChecked;
            };
            */
            return menuItemViewModel;
        }
    }
}
