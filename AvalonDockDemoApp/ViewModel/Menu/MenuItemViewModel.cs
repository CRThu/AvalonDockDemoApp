using AvalonDockDemoApp.ViewModel.Message;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging;
using DryIoc.Messages;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace AvalonDockDemoApp.ViewModel.Menu
{
    public partial class MenuItemViewModel : ObservableRecipient
    {
        [ObservableProperty]
        private string header;

        [ObservableProperty]
        private bool isCheckable;

        [ObservableProperty]
        //[NotifyPropertyChangedRecipients]
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
            Debug.WriteLine($"[MenuItemViewModel]: Click MenuItem. Header: {Header}.");

            WeakReferenceMessenger.Default.Send(
                new RequestDockViewChangeMessage(RequestDockViewChangeType.Open, Header));
        }
    }
}
