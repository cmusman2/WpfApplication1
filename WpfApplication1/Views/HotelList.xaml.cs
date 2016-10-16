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
using System.Windows.Shapes;
using WpfApplication1.Model;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for HotelList.xaml
    /// </summary>
    public partial class HotelList : Window
    {
        public HotelList()
        {
            InitializeComponent();
            hotellist.ItemsSource = DataSource.Hotels;
            cityList.ItemsSource= DataSource.Cities;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (cityList.SelectedItem!=null)
            hotellist.ItemsSource = DataSource.GetHotel(cityList.SelectedItem.ToString());
        }
    }
}
