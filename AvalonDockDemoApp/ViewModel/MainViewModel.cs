using AvalonDockDemoApp.View;
using AvalonDockDemoApp.ViewModel.Dock;
using AvalonDockDemoApp.ViewModel.Menu;
using AvalonDockDemoApp.ViewModel.Message;
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
            Dictionary<string, DockViewWindowType> MenuItemLayoutViews = new()
            {
                // DockWindowDocument
                { "SampleApp A0", DockViewWindowType.Document },
                { "SampleApp A1", DockViewWindowType.Document },
                { "SampleApp A2", DockViewWindowType.Document },
                { "SampleApp B0", DockViewWindowType.Document },
                { "SampleApp B1", DockViewWindowType.Document },
                { "SampleApp B2", DockViewWindowType.Document },
                // DockWindowAnchorable
                { "AnchorableApp", DockViewWindowType.Anchorable },
            };
            MenuTopViewModel = new MenuTopViewModel();
            var layoutVM = new MenuLayoutViewModel();
            MenuTopViewModel.Add(layoutVM);
            layoutVM.Add(new MenuViewsViewModel(MenuItemLayoutViews));
            layoutVM.Add(new MenuViewItemViewModel() { Header = "SampleApp C" });

            var documents = new List<DockWindowBaseViewModel>();
            documents.Add(new SampleApp1ViewModel("SampleApp A0", "SampleApp A0"));

            var anchorables = new List<DockWindowBaseViewModel>();
            anchorables.Add(new SampleAnchorableAppViewModel("AnchorableApp", "AnchorableApp"));

            this.DockManagerViewModel = new DockManagerViewModel(documents, anchorables);
        }
    }
}
