using AvalonDockDemoApp.ViewModel.Dock;
using AvalonDockDemoApp.ViewModel.Theme;
using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalonDockDemoApp.ViewModel.Message
{
    public class DockThemeChangingMessage
    {
        /// <summary>
        /// open/close
        /// </summary>
        public DockTheme Theme { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="value"></param>
        public DockThemeChangingMessage(DockTheme theme)
        {
            Theme = theme;
        }
    }
}
