using AvalonDockDemoApp.ViewModel.Message;
using DryIoc.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace AvalonDockDemoApp.ViewModel.Dock
{
    public class DockWindowAppsFactory
    {
        public Dictionary<string, (DockViewWindowType, Type)> Apps;

        public IEnumerable<string> AppNames => Apps.Keys;

        public DockWindowAppsFactory()
        {
            Apps = new();
        }

        public void Register(string appName, DockViewWindowType windowType, Type vmClassType)
        {
            Apps.Add(appName, (windowType, vmClassType));
        }

        public void Register(IDictionary<string, (DockViewWindowType, Type)> appInfos)
        {
            foreach (var appInfo in appInfos)
            {
                Apps.Add(appInfo.Key, appInfo.Value);
            }
        }

        public DockWindowBaseViewModel? CreateInstance(string appName, string appId, string title)
        {
            var (appWinType, appClass) = Apps[appName];

            if (appClass != null)
            {
                var constructor = appClass.GetConstructor(new Type[] { typeof(string), typeof(string) });
                if (constructor != null)
                {
                    return (DockWindowBaseViewModel)constructor.Invoke(new object[] { appId, title });
                }
                else
                    MessageBox.Show($"appClass.GetConstructor return null, appClass = {appClass}.");
            }
            else
                MessageBox.Show($"Type.GetType return null, appClass = {appClass}.");

            return null;
        }

        public DockViewWindowType GetWindowType(string appName)
        {
            return Apps[appName].Item1;
        }
    }
}
