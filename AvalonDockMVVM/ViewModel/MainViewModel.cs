using AvalonDockMVVM.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;

namespace AvalonDockMVVM.ViewModel
{
    public class MainViewModel
    {
        public DockManagerViewModel DockManagerViewModel { get; private set; }
        public MenuViewModel MenuViewModel { get; private set; }

        public MainViewModel()
        {
            var documents = new List<DockWindowViewModel>();

            for (int i = 0; i < 3; i++)
            {
                documents.Add(new SampleApp1ViewModel() { Title = "SampleApp A" + i.ToString() });
                documents.Add(new SampleApp2ViewModel() { Title = "SampleApp B" + i.ToString() });
            }

            var anchorables = new List<DockWindowAnchorableViewModel>();
            anchorables.Add(new SampleAnchorableAppViewModel() { Title = "AnchorableApp" });

            this.DockManagerViewModel = new DockManagerViewModel(documents, anchorables);
            this.MenuViewModel = new MenuViewModel(documents);
        }
    }
}
