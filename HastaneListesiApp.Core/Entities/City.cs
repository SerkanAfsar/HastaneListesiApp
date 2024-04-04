namespace HastaneListesiApp.Core.Entities
{
    public class City : BaseEntity
    {
        public string CityName { get; set; }
        public string CitySlug { get; set; }
        public virtual List<Hospital> Hospitals { get; set; } = new List<Hospital>();
    }
}
