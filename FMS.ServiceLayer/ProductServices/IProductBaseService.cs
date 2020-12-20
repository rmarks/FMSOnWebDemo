using FMS.ServiceLayer.Dtos;

namespace FMS.ServiceLayer.ProductServices
{
    public interface IProductBaseService
    {
        PagedList<ProductBaseListDto> GetFilterPage(ProductListOptions options);
        ProductBaseInfoDto GetProductBaseInfo(ProductBaseInfoDto info);
    }
}