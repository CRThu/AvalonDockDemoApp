using DryIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AvalonDockDemoApp.ViewModel.Menu
{
    public partial class MenuLayoutViewModel : MenuItemBaseViewModel
    {
        public MenuLayoutViewModel()
        {
            Header = "Layout";
            Items = new();
        }

        public MenuLayoutViewModel(IEnumerable<MenuItemBaseViewModel> itemViewModel) : this()
        {
            foreach (var item in itemViewModel)
            {
                Items.Add(item);
            }

            Separator separator = new Separator();
            Items.Add(separator);


        }
    }
}
