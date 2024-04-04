using HastaneListesiApp.Core.DTOs.ResponseDtos;
using HastaneListesiApp.Core.Utils;

namespace HastaneListesiApp.Core.Exceptions
{
    public class CustomException : Exception
    {
        public string ExceptionMessage { get; set; }
        public List<string> ExceptionMessageList { get; set; } = new List<string>();
        protected readonly ResponseResult<BaseResponseDto> ResponseResult = new ResponseResult<BaseResponseDto>()
        {
            Success = false,
            StatusCode = System.Net.HttpStatusCode.InternalServerError
        };
        public CustomException(string message) : base(message)
        {
            this.ExceptionMessage = message;
            this.ResponseResult.ErrorList.Add(message);
        }
        public CustomException(List<string> messages)
        {
            this.ExceptionMessageList = messages;
            this.ResponseResult.ErrorList.AddRange(messages);
        }


    }
}
