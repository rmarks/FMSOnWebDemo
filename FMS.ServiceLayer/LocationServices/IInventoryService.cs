using FMS.ServiceLayer.Dtos;

namespace FMS.ServiceLayer.LocationServices
{
    public interface IInventoryService
    {
        PagedList<InventoryListItemDto> FilterPage(InventoryListOptions options);
    }
}