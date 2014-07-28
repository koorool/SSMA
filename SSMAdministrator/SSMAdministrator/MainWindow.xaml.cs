using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Demo.WindowsPresentation;
using Demo.WindowsPresentation.CustomMarkers;
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;
using System.Net.NetworkInformation;

namespace SSMAdministrator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //private GMapMarker currentMarker;
        private List<Marker> _markers = new List<Marker>(); 
        public MainWindow()
        {
            InitializeComponent();
            
            gmMain.MapProvider = GMapProviders.YandexMap;
            gmMain.Manager.Mode = AccessMode.ServerAndCache;
            GMapProvider.WebProxy = null;
            gmMain.Position = new PointLatLng(50.44594, 30.5419929);
            gmMain.MinZoom = 1;
            gmMain.MaxZoom = 20;
            //set zoom
            gmMain.Zoom = 10;
            
                //currentMarker = new GMapMarker(gmMain.Position);

            // currentMarker.Shape = new CustomMarkerRed(this, currentMarker, "custom position marker");
            /*
                        currentMarker.Shape = new CustomMarkerRed(this, currentMarker, "custom position marker");
                        currentMarker.Offset = new System.Windows.Point(-15, -15);
                        currentMarker.ZIndex = int.MaxValue;
                        gmMain.Markers.Add(currentMarker);
            */
        }

        private void gmMain_OnMapDrag()
        {
            lCurrPoss.Content = gmMain.Position.ToString();
        }
        /*
                private void gmMain_MouseDoubleClick(object sender, MouseButtonEventArgs e)
                {
                    System.Windows.Point p = e.GetPosition(gmMain);
                    var tmpM = new GMapMarker(gmMain.FromLocalToLatLng((int)p.X, (int)p.Y));
                    gmMain.Markers.Add(tmpM);
                }
         */

        private void bReload_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                gmMain.ReloadMap();
            }
            catch
            {
                MessageBox.Show("Не получается обновить карту. Возможно, произошла ошибка при первоначальной загрузке?");
            }
            
        }
        /*

                private void bAdd_Click(object sender, RoutedEventArgs e)
                {
                    GMapMarker m = new GMapMarker(currentMarker.Position);
                    {
                        m.ZIndex = 55;
                    }
                    gmMain.Markers.Add(m);
                }

                private void gmMain_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
                {
                    System.Windows.Point p = e.GetPosition(gmMain);
                    currentMarker.Position = gmMain.FromLocalToLatLng((int)p.X, (int)p.Y);
                }

                private void gmMain_MouseMove(object sender, MouseEventArgs e)
                {
                    if (e.LeftButton == System.Windows.Input.MouseButtonState.Pressed)
                    {
                        System.Windows.Point p = e.GetPosition(gmMain);
                        currentMarker.Position = gmMain.FromLocalToLatLng((int)p.X, (int)p.Y);
                    }
                }
        */

        private void gmMain_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var p = e.GetPosition(gmMain);
            var wAmd = new wAddMarkerDialog(gmMain.FromLocalToLatLng((int)p.X, (int)p.Y));
            
            wAmd.ShowDialog();
            if (!wAmd.DialogResult.HasValue || !wAmd.DialogResult.Value) return;

            var newGMarker = new GMapMarker(gmMain.FromLocalToLatLng((int) p.X, (int) p.Y));
            newGMarker.Shape = wAmd.rbFreeWare.IsChecked.Value
                ? new CustomMarkerRed(this, newGMarker, wAmd.MarkerName)
                : new CustomMarkerRed(this, newGMarker, wAmd.MarkerName); 
            newGMarker.Offset = new Point(-15,-15);
            newGMarker.ZIndex = int.MaxValue;
            gmMain.Markers.Add(newGMarker);
            var newMarker = new Marker
            {
                GmMarker = newGMarker,
                Description = wAmd.Description,
                Freeware = wAmd.rbFreeWare.IsChecked.Value,
                MarkerName = wAmd.MarkerName,
                Sim = 0
            };
            _markers.Add(newMarker);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DbEngine.GetAllMarkers();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            //gmMain.Markers.Clear();
            //var tmp = DbEngine.GetAllMarkers();
            //foreach (var marker in tmp)
            {
                //gmMain.Markers.Add(marker);
            }
        }
    }
}
