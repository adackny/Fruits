namespace Fruits.Api.Communication.Wrappers
{
    public class Response
    {
        public bool Succeeded { get; }
        public object? Data { get; }
        public ErrorWrapper? Error { get; }

        public Response(object data)
        {
            Succeeded = true;
            Data = data;
        }

        public Response(ErrorWrapper error)
        {
            Succeeded = false;
            Error = error;
        }
    }
}
