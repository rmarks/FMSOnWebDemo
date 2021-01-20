using FMS.ServiceLayer.Dtos;

namespace FMS.ServiceLayer.LocationServices
{
    public interface ILocationService
    {
        PagedList<LocationListItemDto> GetWarehouses(LocationListOptions options);
    }
}