using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalonDockDemoApp.ViewModel.Menu
{
    public partial class MenuTopViewModel : MenuItemBaseViewModel
    {
        public MenuTopViewModel()
        {
            Header = "MenuTop";
            Items = new();
        }

        public void Add(MenuItemBaseViewModel itemViewModel)
        {
            Items.Add(itemViewModel);
        }
    }
}
