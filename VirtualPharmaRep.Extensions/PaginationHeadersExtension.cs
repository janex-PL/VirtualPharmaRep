using Microsoft.AspNetCore.Http;
using VirtualPharmaRep.Data.Dtos.Interfaces;
using VirtualPharmaRep.Data.Pagination;

namespace VirtualPharmaRep.Extensions
{
    public static class PaginationHeadersExtension
    {
        public static void AddPaginationHeaders<T>(this IHeaderDictionary headers, PagedListResponse<T> response) where T : class,IDto
        {
            headers.Add("Pagination-CurrentPage", response.CurrentPage.ToString());
            headers.Add("Pagination-TotalPages", response.TotalPages.ToString());
            headers.Add("Pagination-PageSize", response.PageSize.ToString());
            headers.Add("Pagination-TotalCount", response.TotalCount.ToString());
        }
    }
}
