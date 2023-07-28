using CommunityToolkit.Mvvm.Messaging.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AvalonDockDemoApp.ViewModel.Message
{
    public class MenuItemCreateViewMessage : ValueChangedMessage<string>
    {
        public MenuItemCreateViewMessage(string str) : base(str)
        {

        }
    }
}
