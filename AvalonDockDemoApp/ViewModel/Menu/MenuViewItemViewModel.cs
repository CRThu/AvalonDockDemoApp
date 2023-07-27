using CommunityToolkit.Mvvm.Messaging.Messages;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalonDockDemoApp.ViewModel.Menu
{
    public partial class MenuViewItemViewModel : MenuItemViewModel, IRecipient<PropertyChangedMessage<bool>>
    {
        public MenuViewItemViewModel()
        {
            // Messenger Receive Set
            IsActive = true;
        }

        public void Receive(PropertyChangedMessage<bool> message)
        {

            if (message.Sender is DockWindowViewModel dockVM)
            {
                if (dockVM.Title == Header)
                {
                    IsChecked = !message.NewValue;
                }
            }

        }
    }
}
