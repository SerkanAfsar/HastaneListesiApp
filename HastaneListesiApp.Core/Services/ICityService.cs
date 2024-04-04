using HastaneListesiApp.Core.DTOs.RequestDtos;
using HastaneListesiApp.Core.DTOs.ResponseDtos;
using HastaneListesiApp.Core.Entities;

namespace HastaneListesiApp.Core.Services
{
    public interface ICityService : IServiceBase<CityRequestDto, City, CityResponseDto>
    {
    }
}
