using AvalonDockMVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalonDockMVVM.ViewModel
{
    public class SampleAnchorableAppViewModel : DockWindowAnchorableViewModel
    {
        public string BingText { get; set; } = "Binding SampleAnchorableApp ABC";
    }
}
