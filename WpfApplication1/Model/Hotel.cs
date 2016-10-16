using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApplication1.Views;

namespace WpfApplication1.Model
{

    public class Hotel
    {

        private string imgpath;
        public string id { get; set; }
        public string name { get; set; }
        public string city { get; set; }
        public string address1 { get; set; }
        public string postalCode { get; set; }
        public string country { get; set; }
        public string lowestrate { get; set; }
        public string hotelrating { get; set; }
        public string img { get { if (String.IsNullOrEmpty(imgpath)) imgpath = "http://media.expedia.com/hotels/2000000/1110000/1101900/1101884/1101884_93_t.jpg";return imgpath; } set { imgpath = value; } }

        public hotelsummary HotelSummary { get; set; }
        public List<Image> Images { get; set; }  
        public List<HotelRoom> HotelRooms { get; set; }

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
            
            Hotel h = DataSource.GetHotelById(s);
            if (h != null)
            {
                HotelDetail win = new HotelDetail();
                win.DataContext = h;
                win.Show();
            }else
            {
                MessageBox.Show("Selected not found");
            }

        }

    }


    public class CommandHandler : ICommand
    {
        private Action<string> _action;
        private bool _canExecute;
        public CommandHandler(Action<string> action, bool canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            //if (parameter)
            {
                //MessageBox.Show("button");
            }
            if (parameter != null)
                _action(parameter.ToString());
            else
                _action("no");
        }

    }
}
