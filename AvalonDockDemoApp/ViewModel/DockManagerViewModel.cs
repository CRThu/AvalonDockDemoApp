using AvalonDockDemoApp.Selector;
using AvalonDockDemoApp.View;
using AvalonDockDemoApp.ViewModel.Menu;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AvalonDockDemoApp.ViewModel
{
    public class DockManagerViewModel : ObservableRecipient, IRecipient<PropertyChangedMessage<bool>>
    {
        /// <summary>Gets a collection of all visible documents</summary>
        public ObservableCollection<DockWindowViewModel> Documents { get; private set; }
        public ObservableCollection<DockWindowAnchorableViewModel> Anchorables { get; private set; }
        public DataTemplateSelector DataTemplateSelector { get; set; }

        public DockManagerViewModel()
        {
            // Messenger Receive Set
            IsActive = true;

            DataTemplateSelector = new AvalonDockDataTemplateSelector();
            Documents = new ObservableCollection<DockWindowViewModel>();
            Anchorables = new ObservableCollection<DockWindowAnchorableViewModel>();
        }

        public DockManagerViewModel(IEnumerable<DockWindowViewModel> documents, IEnumerable<DockWindowAnchorableViewModel> anchorables) : this()
        {
            foreach (var document in documents)
            {
                if (!document.IsClosed)
                    Documents.Add(document);
            }
            foreach (var anchorable in anchorables)
            {
                Anchorables.Add(anchorable);
            }
        }

        /*
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
        */

        public void Receive(PropertyChangedMessage<bool> message)
        {
            if (message.Sender is MenuItemViewModel miVM)
            {
                if (message.PropertyName == "IsChecked")
                {
                    if (message.NewValue)
                    {
                        DockWindowViewModel vm;
                        switch (miVM.Header)
                        {
                            case "SampleApp A0":
                            case "SampleApp A1":
                            case "SampleApp A2":
                                vm = new SampleApp1ViewModel() { Title = miVM.Header };
                                break;
                            case "SampleApp B0":
                            case "SampleApp B1":
                            case "SampleApp B2":
                                vm = new SampleApp2ViewModel() { Title = miVM.Header };
                                break;
                            default:
                                throw new NotImplementedException();
                        }
                        Documents.Add(vm);
                    }
                    else
                    {
                        DockWindowViewModel? vm = Documents.Where(n => n.Title == miVM.Header).FirstOrDefault();
                        if (vm != null)
                            Documents.Remove(vm);
                        else
                            MessageBox.Show($"cannot find DockWindowViewModel for {miVM.Header}.");
                    }
                }
            }
        }
    }


}
