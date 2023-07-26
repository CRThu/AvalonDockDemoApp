using AvalonDockDemoApp.Selector;
using AvalonDockDemoApp.View;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AvalonDockDemoApp.ViewModel
{
    public class DockManagerViewModel
    {
        /// <summary>Gets a collection of all visible documents</summary>
        public ObservableCollection<DockWindowViewModel> Documents { get; private set; }
        public ObservableCollection<DockWindowAnchorableViewModel> Anchorables { get; private set; }
        public DataTemplateSelector DataTemplateSelector { get; set; }


        public DockManagerViewModel(IEnumerable<DockWindowViewModel> dockWindowViewModels)
        {
            DataTemplateSelector = new AvalonDockDataTemplateSelector();

            this.Documents = new ObservableCollection<DockWindowViewModel>();

            foreach (var document in dockWindowViewModels)
            {
                document.PropertyChanged += DockWindowViewModel_PropertyChanged;
                if (!document.IsClosed)
                    this.Documents.Add(document);
            }
        }

        public DockManagerViewModel(IEnumerable<DockWindowViewModel> documents, IEnumerable<DockWindowAnchorableViewModel> anchorables)
        {
            DataTemplateSelector = new AvalonDockDataTemplateSelector();

            this.Documents = new ObservableCollection<DockWindowViewModel>();

            foreach (var document in documents)
            {
                document.PropertyChanged += DockWindowViewModel_PropertyChanged;
                if (!document.IsClosed)
                    this.Documents.Add(document);
            }

            this.Anchorables = new ObservableCollection<DockWindowAnchorableViewModel>();

            foreach (var anchorable in anchorables)
            {
                this.Anchorables.Add(anchorable);
            }
        }

        private void DockWindowViewModel_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            DockWindowViewModel document = sender as DockWindowViewModel;

            if (e.PropertyName == nameof(DockWindowViewModel.IsClosed))
            {
                if (!document.IsClosed)
                    this.Documents.Add(document);
                else
                    this.Documents.Remove(document);
            }
        }
    }


}
