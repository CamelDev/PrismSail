using System.Collections.ObjectModel;
using Prism.Mvvm;
using PrismSailCommon;
using PrismSailCommon.Models;

namespace PrismSail.CityDetailsModule.ViewModels
{
    internal class CityDetailsViewModel :BindableBase
    {
        private readonly ICitySearchService _citySearchService;

        private string _cityName = "------";
        public string CityName
        {
            get => _cityName;
            set => SetProperty(ref _cityName, value);
        }

        private decimal _latitude = 0;
        public decimal Latitude
        {
            get => _latitude;
            set => SetProperty(ref _latitude, value);
        }

        private decimal _longitude = 0;
        public decimal Longitude
        {
            get => _longitude;
            set => SetProperty(ref _longitude, value);
        }

        private ObservableCollection<CityProperty> _cityProps = new ObservableCollection<CityProperty>();
        public ObservableCollection<CityProperty> CityProperties
        {
            get => _cityProps;
            set => SetProperty(ref _cityProps, value);
        }

        public CityDetailsViewModel(ICitySearchService citySearchService)
        {
            _citySearchService = citySearchService;
            _citySearchService.CityFound += OnCityFound;
        }

        private void OnCityFound(CityData city)
        {
            CityName = city.Name;
            CityProperties = new ObservableCollection<CityProperty>(city.Props);
            Longitude = city.Longitude;
            Latitude = city.Latitude;
        }
    }
}
