using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace AvalonDockDemoApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            RegisterMessenger();
        }
        
        /// <summary>
        /// Messenger注册方法
        /// </summary>
        private void RegisterMessenger()
        {
            // ChangeTheme注册
            //WeakReferenceMessenger.Default.Register<MainWindow, string, string>(this, "ChangeTheme", static (r, m) => r.ChangeTheme(m));
        }

        /// <summary>
        /// 切换界面主题
        /// </summary>
        /// <param name="theme"><see cref="Theme"/>枚举的字符串类型</param>
        /// <exception cref="NotImplementedException">不存在<see cref="Theme"/>中的枚举</exception>
        //public void ChangeTheme(string theme)
        //{
        //    DockManager.Theme = theme.ToEnum<Theme>() switch
        //    {
        //        Theme.VS2013LightTheme => new AvalonDock.Themes.Vs2013LightTheme(),
        //        Theme.VS2013BlueTheme => new AvalonDock.Themes.Vs2013BlueTheme(),
        //        Theme.VS2013DarkTheme => new AvalonDock.Themes.Vs2013DarkTheme(),
        //        _ => throw new NotImplementedException(),
        //    };
        //}
    }
}
