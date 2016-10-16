using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace WpfApplication1.ViewModel.HtmlConverter
{
    public class FormatValues : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {

            string val = (string)value;
            if (val == "work")
                return 1;
            else
            if (val == "nowork")
                return 2;
            return value;

            // throw new NotImplementedException();
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            int val;
            int.TryParse((string)value, out val);

            if (val == 1) return "work";
            else
            if (val == 2) return "nowork";

            return value;

            throw new NotImplementedException();
        }
    }
}
