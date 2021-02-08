using FMS.ServiceLayer.Dtos;

namespace FMS.ServiceLayer.LocationServices
{
    public interface ILocationService
    {
        string GetLocationName(int locationId);
        PagedList<LocationListItemDto> GetWarehouses(LocationListOptions options);
        PagedList<LocationListItemDto> GetCommissionWarehouses(LocationListOptions options);
    }
}