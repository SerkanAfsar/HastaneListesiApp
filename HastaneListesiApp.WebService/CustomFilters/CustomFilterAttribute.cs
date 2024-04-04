using HastaneListesiApp.Core.DTOs.RequestDtos;
using HastaneListesiApp.Core.DTOs.ResponseDtos;
using HastaneListesiApp.Core.Entities;
using HastaneListesiApp.Core.Services;
using HastaneListesiApp.Core.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace HastaneListesiApp.WebService.CustomFilters
{
    public class CustomFilterAttribute<RequestDto, Domain, ResponseDto> : IAsyncActionFilter
        where RequestDto : BaseRequestDto
        where ResponseDto : BaseResponseDto
        where Domain : BaseEntity
    {

        private readonly ResponseResult<ResponseDto> responseResult;
        private readonly IServiceBase<RequestDto, Domain, ResponseDto> serviceBase;

        public CustomFilterAttribute(IServiceBase<RequestDto, Domain, ResponseDto> serviceBase)
        {
            this.serviceBase = serviceBase;
            this.responseResult = new ResponseResult<ResponseDto>();
        }


        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                this.responseResult.Success = false;
                context.ModelState.Select(a => a.Value).SelectMany(a => a.Errors).ToList().ForEach(a =>
                {
                    this.responseResult.ErrorList.Add(a.ErrorMessage);
                });
                this.responseResult.StatusCode = System.Net.HttpStatusCode.BadRequest;
                context.Result = new BadRequestObjectResult(this.responseResult);
                return;
            }

            var routeId = context.RouteData.Values["id"];
            if (routeId != null)
            {
                var routeIdParse = int.TryParse(routeId.ToString(), out int id);
                if (routeIdParse)
                {
                    var item = await this.serviceBase.GetByIdAsync(id);
                    context.HttpContext.Items["result"] = item;
                }

            }
            await next();
        }
    }
}
