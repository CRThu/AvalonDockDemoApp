using AvalonDockDemoApp.ViewModel.Message;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalonDockDemoApp.ViewModel.Dock
{
    public abstract class DockWindowDocumentViewModel : DockWindowBaseViewModel
    {
        public DockWindowDocumentViewModel(string appId, string title, bool canClose = true, bool isSingleton = true)
            : base(appId, title, canClose, isSingleton)
        {

        }

        public override void OnDockWindowClosed()
        {
            base.OnDockWindowClosed();
            WeakReferenceMessenger.Default.Send(
                new RequestDockViewChangeMessage(RequestDockViewChangeType.Close, Title));
        }
    }
}
