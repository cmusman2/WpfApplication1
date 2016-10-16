using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApplication1.Views;

namespace WpfApplication1.Model
{
    public class HotelRoom
    {

        public HotelRoom(){}

        public String id { get; set; }

        public String roomTypeCode { get; set; }

        public String roomTypeDescription { get; set; }

        public String rateCode { get; set; }

        public String chargeableRate { get; set; }

        public List<String> ValueAdds { get; set; }

        public List<Image> Images { get; set; }


        public String roomsCount { get; set; }
        public String cancellationPolicy { get; set; }
        public String rateKey { get; set; }
        public String averageBaseRate { get; set; }
        public String surchargeTotal { get; set; }
        public String total { get; set; }


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
            RoomBookView win = new RoomBookView();
            // win.browse.Navigate("http://www.lowestroomrates.com/avails/wb203134/" + s);
            //System.Diagnostics.Process.Start("http://www.lowestroomrates.com/avails/wb203134/"+s);

            win.Title = s;
            win.ShowDialog();
        }
    }
}
;