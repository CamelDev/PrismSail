using Prism.Commands;
using Prism.Mvvm;
using PrismSailCommon;
using PrismSailCommon.Models;

namespace PrismSail.CityDetailsModule.ViewModels
{
    internal class CityDetailsViewModel :BindableBase
    {
        private readonly ICitySearchService _citySearchService;
        private string _cityName = "-";
        //public DelegateCommand CityNameCommand { get; private set; }

        public string CityName
        {
            get => _cityName;
            set => SetProperty(ref _cityName, value);
        }

        public CityDetailsViewModel(ICitySearchService citySearchService)
        {
            _citySearchService = citySearchService;
            _citySearchService.CityFound += OnCityFound;
        }

        private void OnCityFound(CityData city)
        {
            CityName = city.Name;
        }
    }
}
