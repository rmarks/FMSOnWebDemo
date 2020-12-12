using FMS.Dal;
using FMS.Domain.Models;
using FMS.ServiceLayer.Dtos;
using FMS.ServiceLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FMS.ServiceLayer.ProductServices
{
    public class ProductBaseService : IProductBaseService
    {
        private readonly FMSContext _context;

        public ProductBaseService(FMSContext context)
        {
            _context = context;
        }

        public PagedList<ProductBase> GetFilterPage(ProductListOptions options)
        {
            var querable = _context.ProductBases
                .AsNoTracking();

            return querable
                .OrderBy(p => p.Code)
                .GetPagedList(options.CurrentPage, options.PageSize);
        }
    }
}
