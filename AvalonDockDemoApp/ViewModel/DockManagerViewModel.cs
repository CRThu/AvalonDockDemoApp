using AvalonDockDemoApp.Selector;
using AvalonDockDemoApp.View;
using AvalonDockDemoApp.ViewModel.Menu;
using AvalonDockDemoApp.ViewModel.Message;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AvalonDockDemoApp.ViewModel
{
    public partial class DockManagerViewModel : ObservableRecipient, IRecipient<RequestDockViewChangeMessage>
    {
        /// <summary>
        /// documents
        /// </summary>
        public ObservableCollection<DockWindowViewModel> Documents { get; private set; }
        public ObservableCollection<DockWindowAnchorableViewModel> Anchorables { get; private set; }

        /// <summary>
        /// active document
        /// </summary>
        [ObservableProperty]
        private DockWindowViewModel activeContent;

        public DataTemplateSelector DataTemplateSelector { get; set; }

        private int SampleCounter { get; set; }

        public DockManagerViewModel()
        {
            // Messenger Receive Set
            IsActive = true;

            DataTemplateSelector = new AvalonDockDataTemplateSelector();
            Documents = new ObservableCollection<DockWindowViewModel>();
            Anchorables = new ObservableCollection<DockWindowAnchorableViewModel>();

            SampleCounter = 0;
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

        public void Receive(RequestDockViewChangeMessage message)
        {
            Debug.WriteLine($"[DockManagerViewModel]: Receive RequestDockViewChangeMessage. Type: {message.Type}, Value: {message.Title}.\n");

            DockWindowViewModel? vm = Documents.Where(n => n.Title == message.Title).FirstOrDefault();

            if (message.Type == RequestDockViewChangeType.Open)
            {
                // 若vm不存在或为非单例窗口则创建
                if (vm == null || !vm.IsSingleton)
                {
                    switch (message.Title)
                    {
                        case "SampleApp A0":
                        case "SampleApp A1":
                        case "SampleApp A2":
                            vm = new SampleApp1ViewModel(message.Title, message.Title);
                            break;
                        case "SampleApp B0":
                        case "SampleApp B1":
                        case "SampleApp B2":
                            vm = new SampleApp2ViewModel(message.Title, message.Title);
                            break;
                        case "SampleApp C":
                            vm = new SampleApp3ViewModel(message.Title, $"{message.Title} #{SampleCounter}");
                            SampleCounter++;
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                    Documents.Add(vm);
                    // 窗体已存在则获取焦点
                    ActiveContent = vm;
                }
                else
                {
                    // 窗体已存在则获取焦点
                    ActiveContent = vm;
                }
            }
            else if (message.Type == RequestDockViewChangeType.Close)
            {
                if (vm != null)
                    Documents.Remove(vm);
                else
                    MessageBox.Show($"cannot find vm which title is {message.Title}.");
            }
        }
    }
}