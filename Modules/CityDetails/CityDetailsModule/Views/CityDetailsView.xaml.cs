using System.Windows.Controls;
using PrismSailCommon;
using PrismSailCommon.Models;

namespace PrismSail.CityDetailsModule.Views
{
    public partial class CityDetailsView : UserControl
    {
        private readonly ICitySearchService _citySearchService;

        public CityDetailsView(ICitySearchService citySearchService)
        {
            _citySearchService = citySearchService;
            InitializeComponent();
            citySearchService.CityFound += OnCityFound;
        }

        private void OnCityFound(CityData city)
        {
            _citySearchService.PresentCityOnMap(city);
        }
    }
}