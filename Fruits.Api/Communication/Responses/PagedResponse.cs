namespace Fruits.Api.Communication.Wrappers
{
    public class PagedResponse : Response
    {
        public int PageNumber { get; }
        public int PageSize { get; }

        public PagedResponse(int pageNumber, int pageSize, object data) : base(data)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }
}
