using System.Windows.Controls;

namespace PrismSail.MapModule.Views
{
    public partial class MapView : UserControl
    {
        public MapView()
        {
            InitializeComponent();
            WbMapBrowser.Navigate("https://www.google.com/maps");
        }
    }
}
