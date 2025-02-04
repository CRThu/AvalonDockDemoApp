﻿using AvalonDock.Controls;
using AvalonDockDemoApp.View;
using AvalonDockDemoApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AvalonDockDemoApp.Selector
{
    public class AvalonDockDataTemplateSelector : DataTemplateSelector
    {

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            // Binding DataTemplate
            DataTemplate SampleApp1Dt = new DataTemplate(typeof(SampleApp1ViewModel))
            {
                VisualTree = new FrameworkElementFactory(typeof(SampleApp1))
            };
            DataTemplate SampleApp2Dt = new DataTemplate(typeof(SampleApp2ViewModel))
            {
                VisualTree = new FrameworkElementFactory(typeof(SampleApp2))
            };
            DataTemplate SampleApp3Dt = new DataTemplate(typeof(SampleApp3ViewModel))
            {
                VisualTree = new FrameworkElementFactory(typeof(SampleApp3))
            };
            DataTemplate SampleAnchorableAppDt = new DataTemplate(typeof(SampleAnchorableAppViewModel))
            {
                VisualTree = new FrameworkElementFactory(typeof(SampleAnchorableApp))
            };

            if (item is SampleApp1ViewModel)
            {
                return SampleApp1Dt;
            }
            else if (item is SampleApp2ViewModel)
            {
                return SampleApp2Dt;
            }
            else if (item is SampleApp3ViewModel)
            {
                return SampleApp3Dt;
            }
            else if (item is SampleAnchorableAppViewModel)
            {
                return SampleAnchorableAppDt;
            }
            else
                return base.SelectTemplate(item, container);
        }
    }
}
