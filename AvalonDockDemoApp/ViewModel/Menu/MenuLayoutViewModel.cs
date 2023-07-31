using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalonDockDemoApp.ViewModel.Menu
{
    public partial class MenuLayoutViewModel : MenuItemBaseViewModel
    {
        public MenuLayoutViewModel()
        {
            Header = "Layout";
            Items = new();
        }

        public void Add(MenuItemBaseViewModel itemViewModel)
        {
            Items.Add(itemViewModel);
        }
    }
}
