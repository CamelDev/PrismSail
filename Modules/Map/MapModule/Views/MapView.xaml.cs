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
        Point _currentPoint;
        Rectangle _bgRect;
        Rectangle _globalRect;

        public MapView(ICitySearchService citySearchService)
        {
            InitializeComponent();

            citySearchService.PresentOnMap += OnPresentOnMap;

            Overlay.Visibility = Visibility.Visible;
            WbMapBrowser.Navigate("https://www.openstreetmap.org");
        }

        private void OnPresentOnMap(CityData obj)
        {
            WbMapBrowser.Visibility = Visibility.Visible;
            var mapUrl = $"www.openstreetmap.org/?lat={FormatCoord(obj.Latitude)}&lon={FormatCoord(obj.Longitude)}&zoom=14&layers=M";
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

            _bgRect =  new Rectangle();
            _bgRect.Stroke = System.Windows.Media.Brushes.Red;
            _bgRect.Fill = System.Windows.Media.Brushes.CadetBlue;
            _bgRect.HorizontalAlignment = HorizontalAlignment.Stretch;
            _bgRect.VerticalAlignment = VerticalAlignment.Stretch;
            _bgRect.Height = 600;
            _bgRect.Width = 700;
            MapCanvas.Children.Add(_bgRect);

            _globalRect = new Rectangle();
            _globalRect.Stroke = System.Windows.Media.Brushes.Black;
            _globalRect.Fill = System.Windows.Media.Brushes.SkyBlue;

            _globalRect.Height = 50;
            _globalRect.Width = 50;

            MapCanvas.Children.Add(_globalRect);

            Canvas.SetTop(_globalRect, 200);
            Canvas.SetLeft(_globalRect, 200);
        }

        private void MapCanvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ButtonState == MouseButtonState.Pressed)
            {
                _currentPoint = e.GetPosition(this);

                Canvas.SetTop(_globalRect, _currentPoint.Y);
                Canvas.SetLeft(_globalRect, _currentPoint.X);
            }
        }

        private void MapCanvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {

                Canvas.SetTop(_globalRect, e.GetPosition(this).Y - 50);
                Canvas.SetLeft(_globalRect, e.GetPosition(this).X - 50);

                Line line = new Line();

                line.Stroke = SystemColors.WindowFrameBrush;
                line.X1 = _currentPoint.X;
                line.Y1 = _currentPoint.Y;
                line.X2 = e.GetPosition(this).X;
                line.Y2 = e.GetPosition(this).Y;

                _currentPoint = e.GetPosition(this);

                MapCanvas.Children.Add(line);
            }
        }
    }
}
