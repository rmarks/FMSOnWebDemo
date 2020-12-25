using FMS.ServiceLayer.Dtos;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.SalesInvoiceServices
{
    public interface ISalesInvoiceService
    {
        Task<SalesInvoiceDto> GetInvoice(int id);
    }
}