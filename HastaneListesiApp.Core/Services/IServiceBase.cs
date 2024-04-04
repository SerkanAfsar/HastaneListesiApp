using HastaneListesiApp.Core.DTOs.RequestDtos;
using HastaneListesiApp.Core.DTOs.ResponseDtos;
using HastaneListesiApp.Core.Entities;
using HastaneListesiApp.Core.Utils;
using System.Linq.Expressions;

namespace HastaneListesiApp.Core.Services
{
    public interface IServiceBase<RequestDto, Domain, ResponseDto>
        where RequestDto : BaseRequestDto
        where Domain : BaseEntity
        where ResponseDto : BaseResponseDto
    {
        Task<ResponseResult<ResponseDto>> GetByIdAsync(int id, CancellationToken cancellationToken = default);
        Task<ResponseResult<ResponseDto>> GetAllAsync(Expression<Func<Domain, bool>> predicate = null, string include = null, CancellationToken cancellationToken = default);
        Task<ResponseResult<ResponseDto>> CreateAsync(RequestDto requestDto, CancellationToken cancellationToken = default);
        Task<ResponseResult<ResponseDto>> UpdateAsync(int id, RequestDto requestDto, CancellationToken cancellationToken = default);
        Task<ResponseResult<ResponseDto>> DeleteAsync(int id, CancellationToken cancellationToken = default);
    }
}
