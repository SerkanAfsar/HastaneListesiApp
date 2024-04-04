using HastaneListesiApp.Core.DTOs.RequestDtos;
using HastaneListesiApp.Core.DTOs.ResponseDtos;
using HastaneListesiApp.Core.Entities;

namespace HastaneListesiApp.Core.Services
{
    public interface IHospitalService : IServiceBase<HospitalRequestDto, Hospital, HospitalResponseDto>
    {
    }
}
