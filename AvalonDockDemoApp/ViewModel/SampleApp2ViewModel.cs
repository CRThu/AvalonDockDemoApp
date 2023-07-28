﻿using AvalonDockDemoApp.View;
using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalonDockDemoApp.ViewModel
{
    public partial class SampleApp2ViewModel : DockWindowViewModel
    {
        [ObservableProperty]
        public string bindText = "Binding SampleApp2 ABC";

        public SampleApp2ViewModel(string title) : base()
        {
            Title = title;
            VmId = $"{nameof(SampleApp2ViewModel)}#{Title}#{Guid.NewGuid()}";
        }
    }
}
