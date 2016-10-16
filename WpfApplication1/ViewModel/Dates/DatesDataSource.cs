using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApplication1.ViewModel.Dates
{
    public  class DatesDataSource
    {

        public  List<string> Months { get { return months(0); } }
        public  List<string> Days { get { return days(0); } }


        public static List<string> months(int month = 0)
        {
            List<string> monthss = new List<string>();
            DateTime nd = DateTime.Now;
            nd = nd.AddMonths(month);
            //nd=nd.AddDays(day);
            for (int i = 0; i < 12; i++)
            {
                if (i > 0)
                    nd = nd.AddMonths(1);
                String monthYear = String.Format("{0} {1}", nd.ToString("MMM"), nd.Year);
                monthss.Add(monthYear);
            }

            return monthss;
        }

        public static List<string> days(int day = 0)
        {
            List<string> dayss = new List<string>();


            DateTime nd = DateTime.Now;
            nd = nd.AddDays(day);

            int days = System.DateTime.DaysInMonth(nd.Year, nd.Month);
            int today = nd.Day;

            int daysLeft = days - today;

            if (daysLeft < 1)
            {
                nd = nd.AddMonths(1);
                daysLeft = System.DateTime.DaysInMonth(nd.Year, nd.Month);
            }


            for (int i = 0; i < daysLeft; i++)
            {
                nd = nd.AddDays(1);
                String monthYear = String.Format("{0} {1}", nd.ToString("ddd"), nd.Day);
                dayss.Add(monthYear);
            }

            return dayss;
        }
    }
}
