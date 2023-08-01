using AvalonDockDemoApp.Utility;
using AvalonDockDemoApp.ViewModel.Dock;
using AvalonDockDemoApp.ViewModel.Message;
using AvalonDockDemoApp.ViewModel.Theme;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Messaging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace AvalonDockDemoApp.ViewModel.Menu
{
    public partial class MenuThemeItemViewModel : MenuItemBaseViewModel
    {
        public MenuThemeItemViewModel() : base()
        {
        }

        public override void OnItemClicked()
        {
            base.OnItemClicked();

            var theme = Header.ToEnum<DockTheme>();
            WeakReferenceMessenger.Default.Send(
                new DockThemeChangingMessage(theme));
        }
    }
}
