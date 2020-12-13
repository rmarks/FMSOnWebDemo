using FMS.ServiceLayer.Dtos;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.ProductServices
{
    public interface IProductDropdownsService
    {
        Task<ProductDropdowns> GetProductDropdowns();
    }
}