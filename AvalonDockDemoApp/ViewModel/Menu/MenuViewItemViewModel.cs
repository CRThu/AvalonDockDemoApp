using CommunityToolkit.Mvvm.Messaging.Messages;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AvalonDockDemoApp.ViewModel.Message;
using CommunityToolkit.Mvvm.Input;
using System.Diagnostics;

namespace AvalonDockDemoApp.ViewModel.Menu
{
    public partial class MenuViewItemViewModel : MenuItemBaseViewModel
    {
        public MenuViewItemViewModel() : base()
        {
        }

        public override void OnItemClicked()
        {
            base.OnItemClicked();
            WeakReferenceMessenger.Default.Send(
                new DockWindowViewChangingMessage(DockViewChangeType.Open, Header));
        }
    }
}
