using FMS.ServiceLayer.Dtos;
using System;
using System.Linq;

namespace FMS.ServiceLayer.Extensions
{
    public static class PagedListExtensions
    {
        public static PagedList<T> GetPagedList<T>(this IQueryable<T> query, int currentPage, int pageSize) where T : class
        {
            var pagedList = new PagedList<T>();
            pagedList.CurrentPage = currentPage;
            pagedList.PageSize = pageSize;
            pagedList.ItemsCount = query.Count();

            var pageCount = (double)pagedList.ItemsCount / pageSize;
            pagedList.PageCount = (int)Math.Ceiling(pageCount);

            var skip = (currentPage - 1) * pageSize;
            pagedList.List = query.Skip(skip).Take(pageSize).ToList();

            return pagedList;
        }
    }
}
