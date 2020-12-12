using FMS.Domain.Models;
using FMS.ServiceLayer.Dtos;

namespace FMS.ServiceLayer.ProductServices
{
    public interface IProductBaseService
    {
        PagedList<ProductBase> GetFilterPage(ProductListOptions options);
    }
}