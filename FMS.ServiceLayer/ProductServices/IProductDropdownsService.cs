using FMS.ServiceLayer.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.ProductServices
{
    public interface IProductDropdownsService
    {
        Task<IDictionary<int, string>> GetProductCollectionsByBrand(int productBrandId = 0);
        Task<IDictionary<int, string>> GetProductDesignsByCollection(int productCollectionId = 0);
        Task<ProductDropdowns> GetProductDropdowns();
        Task<ProductFilterDropdowns> GetProductFilterDropdowns();
        Task<IDictionary<int, string>> GetProductGroupsByType(int productTypeId = 2);
    }
}