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
using WpfApplication1.Model;

namespace WpfApplication1.Views
{
    /// <summary>
    /// Interaction logic for HotelDetail.xaml
    /// </summary>
    public partial class HotelDetail : Window
    {
        public Hotel h;

        public HotelDetail()
        {
            InitializeComponent();
        }
    }
}
