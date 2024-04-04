
namespace HastaneListesiApp.Core.Exceptions
{
    public class CustomNotFoundException : CustomException
    {
        public CustomNotFoundException(string message) : base(message)
        {
            this.ResponseResult.StatusCode = System.Net.HttpStatusCode.NotFound;
        }

        public CustomNotFoundException(List<string> messages) : base(messages)
        {
            this.ResponseResult.StatusCode = System.Net.HttpStatusCode.NotFound;
        }
    }
}
