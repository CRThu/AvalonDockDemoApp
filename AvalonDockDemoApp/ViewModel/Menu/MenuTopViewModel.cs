using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalonDockDemoApp.ViewModel.Menu
{
    public partial class MenuTopViewModel : ObservableObject
    {
        [ObservableProperty]
        private string? name;

        [ObservableProperty]
        private List<MenuItemViewModel> items;

        public MenuTopViewModel()
        {
            Name = "MenuTop";
            Items = new();
        }

        public void Add(MenuItemViewModel itemViewModel)
        {
            Items.Add(itemViewModel);
        }
    }
}
