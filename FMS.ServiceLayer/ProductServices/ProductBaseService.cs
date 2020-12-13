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
            var queryable = _context.ProductBases
                .AsNoTracking();

            if (options.ProductStatusId != 0)
            {
                queryable = queryable.Where(p => p.ProductStatusId == options.ProductStatusId);
            }

            if (options.BusinessLineId != 0)
            {
                queryable = queryable.Where(p => p.BusinessLineId == options.BusinessLineId);
            }

            if (options.ProductSourceTypeId != 0)
            {
                queryable = queryable.Where(p => p.ProductSourceTypeId == options.ProductSourceTypeId);
            }

            if (options.ProductDestinationTypeId != 0)
            {
                queryable = queryable.Where(p => p.ProductDestinationTypeId == options.ProductDestinationTypeId);
            }

            if (options.ProductMaterialId != 0)
            {
                queryable = queryable.Where(p => p.ProductMaterialId == options.ProductMaterialId);
            }

            if (options.ProductGroupId != 0)
            {
                queryable = queryable.Where(p => p.ProductGroupId == options.ProductGroupId);
            }
            else if (options.ProductTypeId != 0)
            {
                queryable = queryable.Where(p => p.ProductTypeId == options.ProductTypeId);
            }

            if (options.ProductDesignId != 0)
            {
                queryable = queryable.Where(p => p.ProductDesignId == options.ProductDesignId);
            }
            else if (options.ProductCollectionId != 0)
            {
                queryable = queryable.Where(p => p.ProductCollectionId == options.ProductCollectionId);
            }
            else if (options.ProductBrandId != 0)
            {
                queryable = queryable.Where(p => p.ProductBrandId == options.ProductBrandId);
            }

            return queryable
                .OrderBy(p => p.Code)
                .GetPagedList(options.CurrentPage, options.PageSize);
        }
    }
}
