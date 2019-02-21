using System.Collections.Generic;

namespace PrismSailCommon.Models
{
    public class CityData
    {
        public string Name { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public List<CityProperty> Props { get; set; }
    }
}
