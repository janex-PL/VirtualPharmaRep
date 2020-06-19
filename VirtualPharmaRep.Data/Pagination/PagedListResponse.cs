using System.Collections.Generic;
using System.Linq;
using VirtualPharmaRep.Data.Entities.Interfaces;

namespace VirtualPharmaRep.Data.Pagination
{
    public class PagedListResponse<T> where T : class
    {
        public int TotalCount { get; set; }
        public int PageSize { get; set; }
        public int CurrentPage { get; set; }
        public int TotalPages { get; set; }
        public List<T> Result { get; set; }
        public PagedListResponse(IReadOnlyCollection<T> result, int pageSize, int currentPage)
        {
            Result = typeof(T).GetInterfaces().First().Name.Contains(nameof(IEntity))
                ? result.Skip((currentPage - 1) * pageSize).Take(pageSize == 0 ? result.Count : pageSize)
                    .ToList()
                : result.ToList();
            PageSize = pageSize > 0 ? pageSize : result.Count;
            CurrentPage = currentPage;
            TotalCount = result.Count;
            TotalPages = pageSize > 0 ? TotalCount / PageSize : 1;
        }
    }
}
