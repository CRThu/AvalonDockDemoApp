using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging.Messages;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Reflection.PortableExecutable;
using AvalonDockDemoApp.ViewModel.Menu;
using System.Windows;

namespace AvalonDockDemoApp.ViewModel
{
    public abstract partial class DockWindowViewModel : ObservableRecipient
    {
        [ObservableProperty]
        private string title;

        [ObservableProperty]
        [NotifyPropertyChangedRecipients]
        private bool isClosed;

        [ObservableProperty]
        private bool canClose;

        [ObservableProperty]
        private string vmId;

        public DockWindowViewModel()
        {
            Title = "<NULL>";
            VmId = $"{nameof(DockWindowViewModel)}#{Title}#{Guid.NewGuid()}";
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
