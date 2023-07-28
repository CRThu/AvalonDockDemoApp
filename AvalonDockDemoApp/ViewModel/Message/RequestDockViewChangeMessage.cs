using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalonDockDemoApp.ViewModel.Message
{
    public enum RequestDockViewChangeType
    {
        Open,
        Close
    }

    public class RequestDockViewChangeMessage
    {
        /// <summary>
        /// Change Type
        /// </summary>
        public RequestDockViewChangeType Type { get; }

        public string Title { get; }

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="value"></param>
        public RequestDockViewChangeMessage(RequestDockViewChangeType type, string title)
        {
            Type = type;
            Title = title;
        }
    }
}
