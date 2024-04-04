using AutoMapper;
using HastaneListesiApp.Core.DTOs.RequestDtos;
using HastaneListesiApp.Core.DTOs.ResponseDtos;
using HastaneListesiApp.Core.Entities;
using HastaneListesiApp.Core.Repositories;
using HastaneListesiApp.Core.Services;
using HastaneListesiApp.Core.UnitOfWorks;

namespace HastaneListesiApp.Services.Services
{
    public class HospitalService : ServiceBase<HospitalRequestDto, Hospital, HospitalResponseDto>, IHospitalService
    {
        public HospitalService(IRepositoryBase<Hospital> repositoryBase, IUnitOfWork unitOfWorks, IMapper mapper) : base(repositoryBase, unitOfWorks, mapper)
        {
        }
    }
}
