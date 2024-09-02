using Restaurants.Application.Restaurants.Dtos;

namespace Restaurants.Application.Common;

public class PagedResult<T>
{
    public PagedResult(IEnumerable<T>items,int totalCount,int pageSize,int pageNumber)
    {
        Items=items;
        TotalItemsCount=totalCount;
        TotalPages =(int)Math.Ceiling(totalCount / (double)pageSize);
        ItemFrom = pageSize * (pageNumber - 1) + 1;
        ItemTo = ItemFrom + pageSize - 1;
    }
    public IEnumerable<T> Items { get; set; }
    public int TotalPages { get; set; }
    public int TotalItemsCount { get; set; }
    public int ItemFrom { get; set; }
    public int ItemTo { get; set; }
}