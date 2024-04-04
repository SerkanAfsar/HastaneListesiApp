using HastaneListesiApp.Core.DTOs.RequestDtos;
using HastaneListesiApp.Core.DTOs.ResponseDtos;
using HastaneListesiApp.Core.Entities;
using HastaneListesiApp.Core.Services;
using HastaneListesiApp.Core.Utils;
using HastaneListesiApp.WebService.CustomFilters;
using Microsoft.AspNetCore.Mvc;

namespace HastaneListesiApp.WebService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ServiceFilter(typeof(CustomFilterAttribute<CityRequestDto, City, CityResponseDto>))]
    public class CitiesController : ControllerBase
    {
        private readonly ICityService cityService;

        public CitiesController(ICityService cityService)
        {
            this.cityService = cityService ?? throw new ArgumentNullException(nameof(cityService));
        }
        [HttpGet("id")]
        public async Task<IActionResult> GetCity(int id)
        {
            var result = HttpContext.Items["result"] as ResponseResult<CityResponseDto>;
            return Ok(result);
        }
    }
}
