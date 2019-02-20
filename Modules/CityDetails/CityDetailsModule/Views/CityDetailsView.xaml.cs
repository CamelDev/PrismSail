using System.Windows.Controls;
using PrismSailCommon;
using PrismSailCommon.Models;

namespace PrismSail.CityDetailsModule.Views
{
    public partial class CityDetailsView : UserControl
    {
        public CityDetailsView(ICitySearchService citySearchService)
        {
            InitializeComponent();
            citySearchService.CityFound += OnCityFound;
        }

        private void OnCityFound(CityData city)
        {
           var name = city.Name;
        }
    }
}