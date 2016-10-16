using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication1.ViewModel
{
    public class CustomTemplateSelector : System.Windows.Controls.DataTemplateSelector
    {
        public DataTemplate FileTemplate { get; set; }
        public DataTemplate DirectoryTemplate { get; set; }
        public DataTemplate CityTemplate { get; set; }

        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            if (item is FileInfo)
                return FileTemplate;
            else if (item is DirectoryInfo)
                return DirectoryTemplate;
            else
                return CityTemplate;
           // return base.SelectTemplate(item, container);
        }
    }
}
