using System.Windows.Controls;
using PrismSailCommon;
using PrismSailCommon.Models;

namespace PrismSail.MapModule.Views
{
    public partial class MapView : UserControl
    {
        private readonly ICitySearchService _citySearchService;

        public MapView(ICitySearchService citySearchService)
        {            
            InitializeComponent();
            WbMapBrowser.Navigate("https://chartco.com");

            _citySearchService = citySearchService;
            _citySearchService.PresentOnMap += OnPresentOnMap;
        }

        private void OnPresentOnMap(CityData obj)
        {
            var mapUrl = $"www.openstreetmap.org/?lat={obj.Latitude}&lon={obj.Longitude}&zoom=17&layers=M";
            WbMapBrowser.Navigate("https://"+mapUrl);
        }
    }
}
