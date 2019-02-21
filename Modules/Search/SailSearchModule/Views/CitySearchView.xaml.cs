using System.Windows;
using System.Windows.Controls;
using PrismSailCommon;

namespace PrismSail.SearchModule.Views
{

    public partial class CitySearchView : UserControl
    {
        public CitySearchView(ICitySearchService citySearchService)
        {
            InitializeComponent();

            citySearchService.CityNotFound += OnCityNotFound;
        }

        private void OnCityNotFound(string msg)
        {
            MessageBox.Show(msg,
                "Search error",
                MessageBoxButton.OK,
                MessageBoxImage.Error);
        }
    }
}
