using HastaneListesiApp.Core.DTOs.ResponseDtos;
using System.Net;

namespace HastaneListesiApp.Core.Utils
{
    public class ResponseResult<T> where T : BaseResponseDto
    {
        public bool Success { get; set; } = true;
        public T? Entity { get; set; } = null;
        public List<T>? Entities { get; set; } = null;
        public List<string> ErrorList { get; set; } = new List<string>();
        public HttpStatusCode StatusCode { get; set; } = HttpStatusCode.OK;
    }
}
