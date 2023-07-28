using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace AvalonDockDemoApp.ViewModel.Dock
{
    public abstract class DockWindowAnchorableViewModel : DockWindowBaseViewModel
    {
        public DockWindowAnchorableViewModel(string appId, string title, bool canClose = true, bool isSingleton = true)
            : base(appId, title, canClose, isSingleton)
        {

        }
    }
}
