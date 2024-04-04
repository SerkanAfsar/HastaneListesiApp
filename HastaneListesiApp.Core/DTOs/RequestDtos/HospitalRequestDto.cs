namespace HastaneListesiApp.Core.DTOs.RequestDtos
{
    public class HospitalRequestDto : BaseRequestDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string EMail { get; set; }
        public string WebSite { get; set; }
        public string CityName { get; set; }
        public string District { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public int CityId { get; set; }

    }
}
