using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PrismSailCommon.OsmUtilities
{
    static class OsmAdapter
    {
        public static async Task<CitySearchResult> SearchByName(string name)
        {
            // DEMO DELAY
            await Task.Delay(2000);

            using (var webClient = new WebClient())
            {
                webClient.Encoding = Encoding.UTF8;
                var url =
                    $"nominatim.openstreetmap.org/search?city={HttpUtility.UrlEncode(name)}&format=json&limit=10&email=kamil.dabrowski@gmail.com";

                var jsonResult = webClient.DownloadString(new Uri("http://" + url));

                var cityData = OsmMapper.MapResultToCityData(jsonResult);

                if (cityData != null)
                {
                    return new CitySearchResult()
                    {
                        Success = true,
                        Data = cityData
                    };
                }
            }

            return new CitySearchResult() {Success = false};
        }
    }
}