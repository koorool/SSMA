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
using GMap;
using GMap.NET;

namespace SSMAdministrator
{
    /// <summary>
    /// Interaction logic for wAddMarkerDialog.xaml
    /// </summary>
    public partial class wAddMarkerDialog : Window
    {
        public PointLatLng CoordPoint;
        public string MarkerName;
        public string Description;
        public bool FreeWare;

        public wAddMarkerDialog(PointLatLng coordPoint)
        {
            InitializeComponent();
            this.CoordPoint = coordPoint;
            lCoords.Content = CoordPoint.ToString();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MarkerName = tbName.Text;
            Description = tbDescription.Text;
            if (rbFreeWare.IsChecked != null) FreeWare = rbFreeWare.IsChecked.Value;
            DialogResult = true;
        }

        private void tbName_GotKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            if (tbName.Text == "Имя")
            {
                tbName.Text = "";
            }
        }

        private void tbDescription_GotFocus(object sender, RoutedEventArgs e)
        {
            if (tbDescription.Text == "Описание")
            {
                tbDescription.Text = "";
            }
        }
    }
}
