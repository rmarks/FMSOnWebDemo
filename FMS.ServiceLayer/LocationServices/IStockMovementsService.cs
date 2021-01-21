using FMS.ServiceLayer.Dtos;

namespace FMS.ServiceLayer.LocationServices
{
    public interface IStockMovementsService
    {
        ProductStockMovementsDto GetProductStockMovements(int productId, int locationId);
    }
}