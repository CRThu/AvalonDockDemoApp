using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DryIoc;

namespace AvalonDockDemoApp.ViewModel
{
    public class ViewModelLocator
    {
        private readonly Container container;

        public ViewModelLocator()
        {
            container = new();

            // Register
            container.Register<MainViewModel>();
        }

        public MainViewModel MainWindow => container.Resolve<MainViewModel>();
    }
}
