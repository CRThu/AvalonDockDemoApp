using AvalonDock.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace AvalonDockMVVM.Selector
{
    public class AvalonDockStyleSelector : StyleSelector
    {
        public Style DocumentStyle { get; set; }
        public Style AnchorableStyle { get; set; }

        public override Style SelectStyle(object item, DependencyObject container)
        {
            if (container is LayoutDocumentItem)
            {
                return DocumentStyle;
            }
            return AnchorableStyle;
        }
    }
}
