using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;
using PrismSailCommon;
using PrismSailCommon.Models;

namespace PrismSail.MapModule.Views
{
    public partial class MapView : UserControl
    {
        private readonly ICitySearchService _citySearchService;
        Point currentPoint = new Point();
        Rectangle bgRect;
        Rectangle globalRect;

        public MapView(ICitySearchService citySearchService)
        {            
            InitializeComponent();

            _citySearchService = citySearchService;
            _citySearchService.PresentOnMap += OnPresentOnMap;

            Overlay.Visibility = Visibility.Visible;
            WbMapBrowser.Navigate("https://www.openstreetmap.org");
        }

        private void OnPresentOnMap(CityData obj)
        {
            WbMapBrowser.Visibility = Visibility.Visible;
            var mapUrl = $"www.openstreetmap.org/?lat={FormatCoord(obj.Latitude)}&lon={FormatCoord(obj.Longitude)}&zoom=17&layers=M";           
            WbMapBrowser.Navigate("https://"+mapUrl);
        }

        private static string FormatCoord(decimal coord)
        {
            var enCulture = System.Globalization.CultureInfo.GetCultureInfo("en-EN");
            return coord.ToString(enCulture);
        }

        private void DrawMe_Click(object sender, RoutedEventArgs e)
        {
            WbMapBrowser.Visibility = Visibility.Hidden;
            MapCanvas.Children.Clear();

            bgRect =  new Rectangle();
            bgRect.Stroke = System.Windows.Media.Brushes.Red;
            bgRect.Fill = System.Windows.Media.Brushes.CadetBlue;
            bgRect.HorizontalAlignment = HorizontalAlignment.Stretch;
            bgRect.VerticalAlignment = VerticalAlignment.Stretch;
            bgRect.Height = 600;
            bgRect.Width = 700;
            MapCanvas.Children.Add(bgRect);

            globalRect = new Rectangle();
            globalRect.Stroke = System.Windows.Media.Brushes.Black;
            globalRect.Fill = System.Windows.Media.Brushes.SkyBlue;

            globalRect.Height = 100;
            globalRect.Width = 100;

            MapCanvas.Children.Add(globalRect);

            Canvas.SetTop(globalRect, 200);
            Canvas.SetLeft(globalRect, 200);
        }

        private void MapCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            //if (e.ButtonState == MouseButtonState.Pressed)
            //{
            //    currentPoint = e.GetPosition(this);

            //    Canvas.SetTop(globalRect, currentPoint.Y);
            //    Canvas.SetLeft(globalRect, currentPoint.X);
            //}
        }

        private void MapCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {

                Canvas.SetTop(globalRect, e.GetPosition(this).Y - 50);
                Canvas.SetLeft(globalRect, e.GetPosition(this).X - 50);

                //Line line = new Line();

                //line.Stroke = SystemColors.WindowFrameBrush;
                //line.X1 = currentPoint.X;
                //line.Y1 = currentPoint.Y;
                //line.X2 = e.GetPosition(this).X;
                //line.Y2 = e.GetPosition(this).Y;

                //currentPoint = e.GetPosition(this);

                //MapCanvas.Children.Add(line);
            }
        }
    }
}
