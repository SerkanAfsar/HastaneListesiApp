using AutoMapper;
using HastaneListesiApp.Core.DTOs.RequestDtos;
using HastaneListesiApp.Core.DTOs.ResponseDtos;
using HastaneListesiApp.Core.Entities;
using Slugify;

namespace HastaneListesiApp.Services.Mappers
{
    public class ProfileMapper : Profile
    {
        public ProfileMapper()
        {
            SlugHelper helper = new SlugHelper();
            CreateMap<CityRequestDto, City>().ForMember(a => a.CitySlug, opt =>
            {
                opt.MapFrom(a => helper.GenerateSlug(a.CityName));
            });
            CreateMap<City, CityResponseDto>();

            CreateMap<HospitalRequestDto, Hospital>();
            CreateMap<Hospital, HospitalResponseDto>();
        }
    }
}
