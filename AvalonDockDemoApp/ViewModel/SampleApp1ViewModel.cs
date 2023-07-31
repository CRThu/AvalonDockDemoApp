using AvalonDockDemoApp.View;
using AvalonDockDemoApp.ViewModel.Dock;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalonDockDemoApp.ViewModel
{
    public partial class SampleApp1ViewModel : DockWindowBaseViewModel
    {
        [ObservableProperty]
        public string bindText = "Binding SampleApp1 ABC";

        public SampleApp1ViewModel(string appId, string title) : base(appId, title)
        {
        }
    }
}
