using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CommunityToolkit.Mvvm.Messaging.Messages;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Reflection.PortableExecutable;
using AvalonDockDemoApp.ViewModel.Menu;
using System.Windows;
using AvalonDockDemoApp.ViewModel.Message;
using System.Diagnostics;

namespace AvalonDockDemoApp.ViewModel
{
    public abstract partial class DockWindowBaseViewModel : ObservableObject
    {
        /// <summary>
        /// 窗体标题
        /// </summary>
        [ObservableProperty]
        private string title;

        /// <summary>
        /// 是否已关闭(未使用)
        /// </summary>
        [ObservableProperty]
        private bool isClosed;

        /// <summary>
        /// 窗体是否可关闭
        /// </summary>
        [ObservableProperty]
        private bool canClose;

        /// <summary>
        /// 应用程序名称
        /// </summary>
        [ObservableProperty]
        private string appId;

        /// <summary>
        /// 实例名称,唯一ID,格式 VM#APPID#GUID
        /// </summary>
        [ObservableProperty]
        private string vmId;

        /// <summary>
        /// 是否为单例
        /// </summary>
        [ObservableProperty]
        private bool isSingleton;

        public DockWindowBaseViewModel()
        {
            Title = "<NULL>";
            AppId = "<NULL>";
            IsSingleton = true;
            CanClose = true;
            IsClosed = false;

            VmId = $"{this.GetType().Name}#{AppId}#{Guid.NewGuid()}";
        }

        public DockWindowBaseViewModel(string appId, string title, bool canClose = true, bool isSingleton = true)
        {
            AppId = appId;
            Title = title;
            CanClose = canClose;
            IsSingleton = isSingleton;

            VmId = $"{this.GetType().Name}#{AppId}#{Guid.NewGuid()}";
        }

        [RelayCommand]
        public void Close()
        {
            SendRequestCloseDockView();
            IsClosed = true;
        }

        public void SendRequestCloseDockView()
        {
            Debug.WriteLine($"[DockWindowViewModel]: Click MenuItem. Title: {Title}.");

            WeakReferenceMessenger.Default.Send(
                new RequestDockViewChangeMessage(RequestDockViewChangeType.Close, Title));
        }
    }
}
