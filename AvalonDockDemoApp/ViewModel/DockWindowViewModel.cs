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

namespace AvalonDockDemoApp.ViewModel
{
    public abstract partial class DockWindowViewModel : ObservableRecipient, IRecipient<PropertyChangedMessage<bool>>
    {
        [ObservableProperty]
        private string title;

        [ObservableProperty]
        [NotifyPropertyChangedRecipients]
        private bool isClosed;

        [ObservableProperty]
        private bool canClose;


        public DockWindowViewModel()
        {
            // Messenger Receive Set
            IsActive = true;

            Title = "<NULL>";
            CanClose = true;
            IsClosed = false;
        }

        [RelayCommand]
        public void Close()
        {
            IsClosed = true;
        }


        public void Receive(PropertyChangedMessage<bool> message)
        {
            if (message.Sender is MenuViewItemViewModel menuItemVM)
            {
                if (menuItemVM.Header == Title)
                {
                    IsClosed = !message.NewValue;
                }
            }
        }
    }
}
