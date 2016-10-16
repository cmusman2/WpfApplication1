﻿using System;
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

namespace WpfApplication1.Views
{
    /// <summary>
    /// Interaction logic for SearchHotelView.xaml
    /// </summary>
    public partial class SearchHotelView : Window
    {
        public SearchHotelView()
        {
            InitializeComponent();
        }


        private void btnSearch_Click(object sender, RoutedEventArgs e)
        {
            HotelList win = new HotelList();
            win.ShowInTaskbar = true;
            win.ShowDialog();
        }
    }
}
