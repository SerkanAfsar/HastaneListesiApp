namespace HastaneListesiApp.Core.Exceptions
{
    public class CustomBadRequestException : CustomException
    {

        public CustomBadRequestException(string message) : base(message)
        {
            this.ResponseResult.StatusCode = System.Net.HttpStatusCode.BadRequest;
        }
        public CustomBadRequestException(List<string> messages) : base(messages)
        {
            this.ResponseResult.StatusCode = System.Net.HttpStatusCode.BadRequest;
        }

    }
}
