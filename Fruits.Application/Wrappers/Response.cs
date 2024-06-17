using Fruits.Domain.Errors;

namespace Fruits.Application.Wrappers
{
    public class Response
    {
        public bool Succeeded { get; }
        public object? Data { get; }
        public Error? Error { get; }

        public Response(object data)
        {
            Succeeded = true;
            Data = data;
        }

        public Response(Error error)
        {
            Succeeded = false;
            Error = error;
        }
    }
}
