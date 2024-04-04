using AutoMapper;
using HastaneListesiApp.Core.DTOs.RequestDtos;
using HastaneListesiApp.Core.DTOs.ResponseDtos;
using HastaneListesiApp.Core.Entities;
using HastaneListesiApp.Core.Repositories;
using HastaneListesiApp.Core.Services;
using HastaneListesiApp.Core.UnitOfWorks;
using HastaneListesiApp.Core.Utils;
using System.Linq.Expressions;

namespace HastaneListesiApp.Services.Services
{
    public class ServiceBase<RequestDto, Domain, ResponseDto> : IServiceBase<RequestDto, Domain, ResponseDto>
        where RequestDto : BaseRequestDto
        where Domain : BaseEntity
        where ResponseDto : BaseResponseDto

    {
        protected readonly IUnitOfWork unitOfWorks;
        protected readonly IRepositoryBase<Domain> repositoryBase;
        private readonly ResponseResult<ResponseDto> responseResult;
        private readonly IMapper mapper;
        public ServiceBase(IRepositoryBase<Domain> repositoryBase, IUnitOfWork unitOfWorks, IMapper mapper)
        {
            this.unitOfWorks = unitOfWorks ?? throw new ArgumentNullException(nameof(unitOfWorks));
            this.repositoryBase = repositoryBase ?? throw new ArgumentNullException(nameof(repositoryBase));
            this.responseResult = new ResponseResult<ResponseDto>();
            this.mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }


        public virtual async Task<ResponseResult<ResponseDto>> CreateAsync(RequestDto requestDto, CancellationToken cancellationToken = default)
        {
            this.responseResult.Entity = this.mapper.Map<ResponseDto>(await this.repositoryBase.CreateAsync(this.mapper.Map<Domain>(requestDto), cancellationToken));
            await this.unitOfWorks.CommitChangesAsync(cancellationToken);
            return this.responseResult;
        }

        public virtual async Task<ResponseResult<ResponseDto>> DeleteAsync(int id, CancellationToken cancellationToken = default)
        {
            this.responseResult.Entity = this.mapper.Map<ResponseDto>(await this.repositoryBase.DeleteAsync(id, cancellationToken));
            await this.unitOfWorks.CommitChangesAsync(cancellationToken);
            return this.responseResult;
        }

        public virtual async Task<ResponseResult<ResponseDto>> GetAllAsync(Expression<Func<Domain, bool>> predicate = null, string include = null, CancellationToken cancellationToken = default)
        {
            this.responseResult.Entities = this.mapper.Map<List<ResponseDto>>(await this.repositoryBase.GetAllAsync(predicate, include, cancellationToken));
            return this.responseResult;
        }

        public virtual async Task<ResponseResult<ResponseDto>> GetByIdAsync(int id, CancellationToken cancellationToken = default)
        {
            this.responseResult.Entity = this.mapper.Map<ResponseDto>(await this.repositoryBase.GetById(id, cancellationToken));
            return this.responseResult;
        }

        public virtual async Task<ResponseResult<ResponseDto>> UpdateAsync(int id, RequestDto requestDto, CancellationToken cancellationToken = default)
        {
            this.responseResult.Entity = this.mapper.Map<ResponseDto>(await this.repositoryBase.UpdateAsync(id, this.mapper.Map<Domain>(requestDto), cancellationToken));
            return this.responseResult;
        }
    }
}
