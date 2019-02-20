using Prism.Commands;
using Prism.Mvvm;

namespace PrismSail.SearchModule.ViewModels
{
    public class CitySearchViewModel : BindableBase
    {
        private string _searchCity = "City...";
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
            get { return _isEnabled; }
            set
            {
                SetProperty(ref _isEnabled, value);
                ExecuteDelegateCommand.RaiseCanExecuteChanged();
            }
        }
        public DelegateCommand ExecuteDelegateCommand { get; private set; }

        public CitySearchViewModel()
        {
            ExecuteDelegateCommand = new DelegateCommand(SearchCityByName, CanExecute);
        }

        private void SearchCityByName()
        {
            SearchCityLabel = SearchCity;
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
