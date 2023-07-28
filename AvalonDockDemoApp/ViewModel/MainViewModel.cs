using AvalonDockDemoApp.View;
using AvalonDockDemoApp.ViewModel.Dock;
using AvalonDockDemoApp.ViewModel.Menu;
using DryIoc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace AvalonDockDemoApp.ViewModel
{
    public class MainViewModel
    {
        public DockManagerViewModel DockManagerViewModel { get; private set; }
        public MenuTopViewModel MenuTopViewModel { get; private set; }

        public MainViewModel()
        {
            List<string> MenuItemLayoutViewNamesList = new()
            {
                "SampleApp A0",
                "SampleApp A1",
                "SampleApp A2",
                "SampleApp B0",
                "SampleApp B1",
                "SampleApp B2"
            };
            MenuTopViewModel = new MenuTopViewModel();
            var layoutVM = new MenuLayoutViewModel();
            MenuTopViewModel.Add(layoutVM);
            layoutVM.Add(new MenuViewsViewModel(MenuItemLayoutViewNamesList));
            layoutVM.Add(new MenuItemViewModel() { Header = "SampleApp C" });

            var documents = new List<DockWindowDocumentViewModel>();
            documents.Add(new SampleApp1ViewModel("SampleApp A0", "SampleApp A0"));

            var anchorables = new List<DockWindowAnchorableViewModel>();
            anchorables.Add(new SampleAnchorableAppViewModel("AnchorableApp", "AnchorableApp"));

            this.DockManagerViewModel = new DockManagerViewModel(documents, anchorables);
        }
    }
}
