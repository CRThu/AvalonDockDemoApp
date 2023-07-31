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

namespace AvalonDockDemoApp.ViewModel.Dock
{
    public partial class DockManagerViewModel : ObservableRecipient, IRecipient<DockWindowViewChangingMessage>
    {
        /// <summary>
        /// documents
        /// </summary>
        public ObservableCollection<DockWindowBaseViewModel> Documents { get; private set; }
        public ObservableCollection<DockWindowBaseViewModel> Anchorables { get; private set; }

        public IEnumerable<DockWindowBaseViewModel> Windows
        {
            get
            {
                return Documents.Concat(Anchorables);
            }
        }

        /// <summary>
        /// active document
        /// </summary>
        [ObservableProperty]
        private DockWindowBaseViewModel activeContent;

        public DataTemplateSelector DataTemplateSelector { get; set; }

        private int SampleCounter { get; set; }

        public DockManagerViewModel()
        {
            // Messenger Receive Set
            IsActive = true;

            DataTemplateSelector = new AvalonDockDataTemplateSelector();
            Documents = new ObservableCollection<DockWindowBaseViewModel>();
            Anchorables = new ObservableCollection<DockWindowBaseViewModel>();

            SampleCounter = 0;
        }

        public DockManagerViewModel(IEnumerable<DockWindowBaseViewModel> documents, IEnumerable<DockWindowBaseViewModel> anchorables) : this()
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

        public void Receive(DockWindowViewChangingMessage message)
        {
            Debug.WriteLine($"[DockManagerViewModel]: Receive DockWindowViewChangingMessage. Type: {message.ChangeType}, Value: {message.Title}.\n");
            OnDockWindowViewChange(message);
        }

        public void OnDockWindowViewChange(DockWindowViewChangingMessage message)
        {
            DockWindowBaseViewModel? vm = Windows.Where(n => n.Title == message.Title).FirstOrDefault();
            DockWindowBaseViewModel newVm;

            if (message.ChangeType == DockViewChangeType.Open)
            {
                // 若vm不存在或为非单例窗口则创建
                if (vm == null || !vm.IsSingleton)
                {
                    switch (message.Title)
                    {
                        case "SampleApp A0":
                        case "SampleApp A1":
                        case "SampleApp A2":
                            newVm = new SampleApp1ViewModel(message.Title, message.Title);
                            break;
                        case "SampleApp B0":
                        case "SampleApp B1":
                        case "SampleApp B2":
                            newVm = new SampleApp2ViewModel(message.Title, message.Title);
                            break;
                        case "SampleApp C":
                            newVm = new SampleApp3ViewModel(message.Title, $"{message.Title} #{SampleCounter}");
                            SampleCounter++;
                            break;
                        case "AnchorableApp":
                            newVm = new SampleAnchorableAppViewModel(message.Title, message.Title);
                            break;
                        default:
                            MessageBox.Show($"cannot find vm which title is {message.Title}.");
                            return;
                    }

                    if (message.WindowType == DockViewWindowType.Document)
                        Documents.Add(newVm);
                    else if (message.WindowType == DockViewWindowType.Anchorable)
                        Anchorables.Add(newVm);
                    else
                        throw new NotImplementedException();

                    // 窗体已存在则获取焦点
                    ActiveContent = newVm;
                }
                else
                {
                    // 窗体已存在则获取焦点
                    ActiveContent = vm;
                }
            }
            else if (message.ChangeType == DockViewChangeType.Close)
            {
                DockWindowBaseViewModel? docVm = Documents.Where(n => n.Title == message.Title).FirstOrDefault();
                DockWindowBaseViewModel? anchVm = Anchorables.Where(n => n.Title == message.Title).FirstOrDefault();

                if (docVm != null)
                    Documents.Remove(vm);
                else if (anchVm != null)
                    Anchorables.Remove(anchVm);
                else
                    MessageBox.Show($"cannot find vm which title is {message.Title}.");
            }
        }
    }
}