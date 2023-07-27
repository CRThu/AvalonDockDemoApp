using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AvalonDockDemoApp.ViewModel.Menu
{
    public partial class MenuItemViewModel : ObservableObject
    {
        [ObservableProperty]
        private string header;
        [ObservableProperty]
        private bool isCheckable;
        [ObservableProperty]
        private bool isChecked;
        [ObservableProperty]
        private List<MenuItemViewModel> items;

        public MenuItemViewModel()
        {
            Header = "<NULL>";
            IsCheckable = false;
            IsChecked = false;
            Items = new List<MenuItemViewModel>();
        }

        [RelayCommand]
        public void Click()
        {
            MessageBox.Show($"Click MenuItem.\n" +
                $"Header: {Header}\n" +
                $"IsCheckable: {IsCheckable}\n" +
                $"IsChecked: {IsChecked}");
        }
    }
}
