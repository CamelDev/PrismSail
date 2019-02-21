namespace PrismSailCommon.Models
{
    public class CityProperty
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public CityProperty(string name, string value)
        {
            Name = name;
            Value = value;
        }
    }
}
