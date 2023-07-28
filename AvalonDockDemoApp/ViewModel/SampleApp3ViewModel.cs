using AvalonDockDemoApp.View;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalonDockDemoApp.ViewModel
{
    public partial class SampleApp3ViewModel : DockWindowViewModel
    {
        [ObservableProperty]
        public string bindText = "Binding SampleApp3 ABC";

        public SampleApp3ViewModel(string appId, string title) : base(appId, title, isSingleton: false)
        {
        }
    }
}
