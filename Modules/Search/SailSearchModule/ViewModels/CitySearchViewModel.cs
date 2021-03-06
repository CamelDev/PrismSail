﻿using Prism.Commands;
using Prism.Mvvm;
using PrismSailCommon;

namespace PrismSail.SearchModule.ViewModels
{
    public class CitySearchViewModel : BindableBase
    {
        private readonly ICitySearchService _citySearchService;
        private string _searchCity = "Kraków";
        public string SearchCity
        {
            get => _searchCity;
            set
            {
                SetProperty(ref _searchCity, value);
                SearchCityLabel = value;
            }
        }

        private string _searchCityLabel;
        public string SearchCityLabel
        {
            get => _searchCityLabel;
            set => SetProperty(ref _searchCityLabel, SetSearchCityLabel());
        }

        private bool _isEnabled = true;
        public bool IsEnabled
        {
            get => _isEnabled;
            set
            {
                SetProperty(ref _isEnabled, value);
                ExecuteDelegateCommand.RaiseCanExecuteChanged();
            }
        }
        public DelegateCommand ExecuteDelegateCommand { get; private set; }

        public CitySearchViewModel(ICitySearchService citySearchService)
        {
            _citySearchService = citySearchService;
            ExecuteDelegateCommand = new DelegateCommand(SearchCityByName, CanExecute);
        }

        private void SearchCityByName()
        {
            SearchCityLabel = SearchCity;
            // awaitable?
            _citySearchService.SearchByNameAsync(SearchCity);
        }

        private bool CanExecute()
        {
            return IsEnabled;
        }

        private string SetSearchCityLabel()
        {
            return $"Your search city: {SearchCity}";
        }

    }
}
