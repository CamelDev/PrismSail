using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrismSailCommon.Models;

namespace PrismSailCommon
{
    public class CitySearchService : ICitySearchService
    {
        public void SearchByName(string name)
        {
            var city = new CityData()
            {
                Name = "Testowe",
                Latitude = new decimal(51.6),
                Longitude = new decimal(0.06),
                Props = GetProps()
            };

            CityFound?.Invoke(city);
        }

        private static Dictionary<string, string> GetProps()
        {
            var props = new Dictionary<string, string>
            {
                {"Population", "1.2mln"}, 
                {"Area", "12sqr miles"},
            };

            return props;
        }

        public event Action<string> CityNotFound;
        public event Action<CityData> CityFound;
    }

    public interface ICitySearchService
    {
        void SearchByName(string name);
        event System.Action<string> CityNotFound;
        event System.Action<CityData> CityFound;
    }
}
