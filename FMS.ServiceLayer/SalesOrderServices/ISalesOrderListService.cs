using FMS.ServiceLayer.Dtos;

namespace FMS.ServiceLayer.SalesOrderServices
{
    public interface ISalesOrderListService
    {
        PagedList<SalesOrderListItemDto> FilterPage(SalesOrderListOptions options);
    }
}