using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using PrismSailCommon.Models;

namespace PrismSailCommon.OsmUtilities
{
    static class OsmMapper
    {
        
        public static CityData MapResultToCityData(string jsonData)
        {
            if (string.IsNullOrEmpty(jsonData)) return null;

            var cityData = JsonConvert.DeserializeObject<List<OsmSearchResult>>(jsonData).FirstOrDefault();

            if (cityData != null)
            {
                return new CityData()
                {
                    Name = cityData.display_name.Split(',')[0],
                    Latitude = cityData.lat,
                    Longitude = cityData.lon,
                    Props = GetProps(cityData)
                };
            }

            return null;
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
    }
}
