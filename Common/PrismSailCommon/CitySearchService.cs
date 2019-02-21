using System;
using System.Collections.Generic;

using PrismSailCommon.Models;

namespace PrismSailCommon
{
    public class CitySearchService : ICitySearchService
    {
        public void SearchByName(string name)
        {
            var city = new CityData()
            {
                Name = "Bielsko",
                Latitude = new decimal(51.6),
                Longitude = new decimal(0.06),
                Props = GetProps()
            };

            CityFound?.Invoke(city);
        }

        public void PresentCityOnMap(CityData city)
        {
            PresentOnMap?.Invoke(city);
        }

        private static List<CityProperty> GetProps()
        {
            var props = new List<CityProperty>
            {
                new CityProperty("Population", "1.2mln"), 
                new CityProperty("Area", "12sqr miles"),
            };

            for (int i = 0; i < 1000; i++)
            {
                props.Add(new CityProperty($"Prop-{i}", $"Value-{i}"));
            }

            return props;
        }

        public event Action<string> CityNotFound;
        public event Action<CityData> CityFound;
        public event System.Action<CityData> PresentOnMap;
    }

    public interface ICitySearchService
    {
        void SearchByName(string name);
        void PresentCityOnMap(CityData city);
        event System.Action<string> CityNotFound;
        event System.Action<CityData> PresentOnMap;
        event System.Action<CityData> CityFound;
    }
}
