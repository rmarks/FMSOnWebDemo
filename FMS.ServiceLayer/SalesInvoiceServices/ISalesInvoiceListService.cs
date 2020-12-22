using FMS.ServiceLayer.Dtos;

namespace FMS.ServiceLayer.SalesInvoiceServices
{
    public interface ISalesInvoiceListService
    {
        PagedList<SalesInvoiceListItemDto> FilterPage(SalesInvoiceListOptions options);
    }
}