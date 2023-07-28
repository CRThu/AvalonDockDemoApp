using AvalonDockDemoApp.View;
using AvalonDockDemoApp.ViewModel.Dock;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalonDockDemoApp.ViewModel
{
    public class SampleAnchorableAppViewModel : DockWindowAnchorableViewModel
    {
        public string BingText { get; set; } = "Binding SampleAnchorableApp ABC";
        public SampleAnchorableAppViewModel(string appId, string title) : base(appId, title)
        {
        }
    }
}
