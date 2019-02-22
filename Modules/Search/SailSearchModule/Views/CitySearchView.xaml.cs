using System.Windows;
using System.Windows.Controls;
using PrismSailCommon;
using PrismSailCommon.Models;

namespace PrismSail.SearchModule.Views
{
    public partial class CitySearchView : UserControl
    {
        public CitySearchView(ICitySearchService citySearchService)
        {
            InitializeComponent();

            citySearchService.CitySearchBegin += OnCitySearchBegin;
            citySearchService.CityFound += OnCityFound;
            citySearchService.CityNotFound += OnCityNotFound;
        }

        private void OnCitySearchBegin(string obj)
        {
            SearchingBar.Visibility = Visibility.Visible;
        }

        private void OnCityFound(CityData obj)
        {
            SearchingBar.Visibility = Visibility.Hidden;
        }

        private void OnCityNotFound(string msg)
        {
            MessageBox.Show(msg,
                "Search error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
            SearchingBar.Visibility = Visibility.Hidden;
        }
    }
}
