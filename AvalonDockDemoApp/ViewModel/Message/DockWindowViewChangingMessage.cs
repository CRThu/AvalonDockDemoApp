using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalonDockDemoApp.ViewModel.Message
{
    public enum DockViewChangeType
    {
        Open,
        Close
    }

    public class DockWindowViewChangingMessage
    {
        /// <summary>
        /// open/close
        /// </summary>
        public DockViewChangeType ChangeType { get; }

        public string Title { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="value"></param>
        public DockWindowViewChangingMessage(DockViewChangeType changeType, string title)
        {
            ChangeType = changeType;
            Title = title;
        }
    }
}
