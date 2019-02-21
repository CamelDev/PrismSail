using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using Newtonsoft.Json;
using PrismSailCommon.Models;
using System.Web;

namespace PrismSailCommon
{
    public class CitySearchService : ICitySearchService
    {
        public void SearchByName(string name)
        {
            using (var w = new WebClient())
            {
                w.Encoding = System.Text.Encoding.UTF8;
                var url =
                    $"nominatim.openstreetmap.org/search?city={HttpUtility.UrlEncode(name)}&format=json&limit=10&email=kamil.dabrowski@gmail.com";

                try
                {
                    var jsonData = w.DownloadString("http://" + url);

                    if (!string.IsNullOrEmpty(jsonData))
                    {
                        var cityData = JsonConvert.DeserializeObject<List<OsmSearchResult>>(jsonData).FirstOrDefault();

                        if (cityData != null)
                        {
                            var city = new CityData()
                            {
                                Name = cityData.display_name.Split(',')[0],
                                Latitude = cityData.lat,
                                Longitude = cityData.lon,
                                Props = GetProps(cityData)
                            };

                            CityFound?.Invoke(city);
                        }
                    }

                    CityNotFound?.Invoke($"No results for: '{name}'");
                }
                catch (Exception e)
                {
                    CityNotFound?.Invoke($"Search error: {e.Message}");
                }
            }
        }

        public void PresentCityOnMap(CityData city)
        {
            PresentOnMap?.Invoke(city);
        }

        private static List<CityProperty> GetProps(OsmSearchResult osmResult)
        {
            var props = new List<CityProperty>
            {
                new CityProperty("OSM ID", osmResult.osm_id),
                new CityProperty("Name", osmResult.display_name),
                new CityProperty("Place ID", osmResult.place_id.ToString()),
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