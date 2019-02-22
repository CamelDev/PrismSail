using System;
using System.Threading.Tasks;
using PrismSailCommon.Models;
using PrismSailCommon.OsmUtilities;

namespace PrismSailCommon
{
    public class CitySearchService : ICitySearchService
    {
        public async Task SearchByNameAsync(string name)
        {
            CitySearchBegin?.Invoke($"Searching for: {name}");
            try
            {
                var city = await OsmAdapter.SearchByName(name);

                if (city != null)
                {
                    CityFound?.Invoke(city.Data);
                }
            }
            catch (Exception e)
            {
                CityNotFound?.Invoke($"Search error: {e.Message}");
            }
        }

        public void PresentCityOnMap(CityData city)
        {
            PresentOnMap?.Invoke(city);
        }

        public event Action<string> CitySearchBegin;
        public event Action<string> CityNotFound;
        public event Action<CityData> CityFound;
        public event Action<CityData> PresentOnMap;
    }

    public interface ICitySearchService
    {
        Task SearchByNameAsync(string name);
        void PresentCityOnMap(CityData city);
        event Action<string> CitySearchBegin;
        event Action<string> CityNotFound;
        event Action<CityData> PresentOnMap;
        event Action<CityData> CityFound;
    }
}