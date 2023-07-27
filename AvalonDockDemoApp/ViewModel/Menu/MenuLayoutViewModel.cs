using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalonDockDemoApp.ViewModel.Menu
{
    public partial class MenuLayoutViewModel : MenuItemViewModel
    {
        public MenuLayoutViewModel()
        {
            Header = "Layout";
            Items = new();
        }

        public void Add(MenuItemViewModel itemViewModel)
        {
            Items.Add(itemViewModel);
        }
    }
}
