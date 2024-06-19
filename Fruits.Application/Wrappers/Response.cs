namespace Fruits.Application.Wrappers
{
    public struct Response
    {
        public bool Succeeded { get; }
        public object? Data { get; }
        public ErrorResponse? Error { get; }

        public Response(object data)
        {
            Succeeded = true;
            Data = data;
        }

        public Response(ErrorResponse error)
        {
            Succeeded = false;
            Error = error;
        }
    }
}
