using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AvalonDockDemoApp.ViewModel
{
    public abstract partial class DockWindowViewModel : ObservableObject
    {
        [ObservableProperty]
        private string title;

        [ObservableProperty]
        private bool isClosed;

        [ObservableProperty]
        private bool canClose;


        public DockWindowViewModel()
        {
            Title = "<NULL>";
            CanClose = true;
            IsClosed = false;
        }

        [RelayCommand]
        public void Close()
        {
            IsClosed = true;
        }
    }
}
