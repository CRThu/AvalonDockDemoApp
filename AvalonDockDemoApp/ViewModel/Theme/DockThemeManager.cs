using AvalonDockDemoApp.Selector;
using AvalonDockDemoApp.Utility;
using AvalonDockDemoApp.ViewModel.Message;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using DryIoc;
using DryIoc.Messages;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace AvalonDockDemoApp.ViewModel.Theme
{
    public partial class DockThemeManager : ObservableRecipient, IRecipient<DockThemeChangingMessage>
    {
        /// <summary>
        /// 当前主题
        /// </summary>
        [ObservableProperty]
        private AvalonDock.Themes.Theme selectedTheme;

        /// <summary>
        /// 主题列表
        /// </summary>
        public ObservableCollection<string> Themes
            => new(EnumEx.GetAllItems<DockTheme>().Select(t => t.ToString()));


        public DockThemeManager()
        {
            // Messenger Receive Set
            IsActive = true;

            ChangeTheme(DockTheme.VS2013LightTheme);
        }

        public void Receive(DockThemeChangingMessage message)
        {
            ChangeTheme(message.Theme);
        }

        public void ChangeTheme(DockTheme theme)
        {
            SelectedTheme = theme switch
            {
                DockTheme.VS2013LightTheme => new AvalonDock.Themes.Vs2013LightTheme(),
                DockTheme.VS2013BlueTheme => new AvalonDock.Themes.Vs2013BlueTheme(),
                DockTheme.VS2013DarkTheme => new AvalonDock.Themes.Vs2013DarkTheme(),
                _ => throw new NotImplementedException(),
            };
        }
    }
}
