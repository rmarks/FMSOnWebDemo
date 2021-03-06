﻿using FMS.Dal;
using FMS.ServiceLayer.Dtos;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace FMS.ServiceLayer.DeliveryNoteServices
{
    public class DeliveryNoteService : IDeliveryNoteService
    {
        private readonly FMSContext _context;

        public DeliveryNoteService(FMSContext context)
        {
            _context = context;
        }

        public async Task<DeliveryNoteDto> GetDeliveryNoteDocument(int id)
        {
            return await _context.Documents
                .AsNoTracking()
                .Where(d => d.Id == id)
                .Select(d => new DeliveryNoteDto
                {
                    Id = d.Id,
                    DeliveryNo = d.DocumentNo,
                    DeliveryDate = d.DocumentDate,
                    ToLocationName = d.DocumentType.IOL == 1 ? d.Location.Name : d.ToFromLocation.Name,
                    FromLocationName = d.DocumentType.IOL == 1 ? d.ToFromLocation.Name : d.Location.Name,
                    IsClosed = d.IsClosed,
                    Lines = d.DocumentLines.OrderBy(l => l.Product.Code).Select(l => new DeliveryNoteLineDto
                    {
                        Id = l.Id,
                        DeliveryNoteId = l.DocumentId,
                        ProductCode = l.Product.Code,
                        ProductName = l.Product.Name,
                        DeliveredQuantity = l.Quantity
                    })
                    .ToList()
                })
                .FirstOrDefaultAsync();
        }
    }
}
