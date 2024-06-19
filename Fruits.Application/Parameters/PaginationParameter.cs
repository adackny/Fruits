namespace Fruits.Application.Parameters
{
    public class PaginationParameter
    {
        private const int MAX_PAGE_SIZE = 20;

        private int _pageNumber = 1;
        private int _pageSize = MAX_PAGE_SIZE;

        public int PageNumber
        {
            get => _pageNumber;
            set => _pageNumber = value < 1 ? 1 : value;
        }

        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = value > MAX_PAGE_SIZE ? MAX_PAGE_SIZE : value;
        }
    }
}
