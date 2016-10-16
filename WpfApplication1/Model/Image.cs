using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using WpfApplication1.Views;

namespace WpfApplication1.Model
{
    public class Image
    {
        public String id { get; set; }

        public String url { get; set; }

        public String thumbNail { get; set; }

        public String caption { get; set; }


        private CommandHandler _clickCommand;
        public ICommand ClickCommand
        {
            get
            {
                if (_clickCommand == null)
                    _clickCommand = new CommandHandler(MyAction, true);
                return _clickCommand;
                //return _clickCommand ?? (_clickCommand = new CommandHandler(() => MyAction(), _canExecute));
            }
        }

        private bool _canExecute;

        public void MyAction(String s)
        {
            s = s.Replace("_t.", "_z.");

            ImageView win = new ImageView();
            var bmp = new BitmapImage();
            bmp.BeginInit();
            bmp.CacheOption = BitmapCacheOption.OnLoad;
            bmp.UriSource = new Uri(s, UriKind.RelativeOrAbsolute);
            bmp.EndInit();

            win.mainimage.Source = bmp;
            win.ShowDialog();
        }

    }
}
