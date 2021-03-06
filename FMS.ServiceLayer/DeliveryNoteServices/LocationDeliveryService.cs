﻿using FMS.Dal;
using FMS.ServiceLayer.Dtos;
using FMS.ServiceLayer.Extensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace FMS.ServiceLayer.DeliveryNoteServices
{
    public class LocationDeliveryService : ILocationDeliveryService
    {
        private readonly FMSContext _context;

        public LocationDeliveryService(FMSContext context)
        {
            _context = context;
        }

        public PagedList<LocationDeliveryListItemDto> ReceiptFilterPage(DeliveryListOptions options)
        {
            var queryable = _context.Documents
                .AsNoTracking()
                .Where(d => d.DocumentType.Code == "VL");

            if (options.ToLocationId != 0)
            {
                queryable = queryable.Where(d => d.LocationId == options.ToLocationId);
            }

            if (options.FromLocationId != 0)
            {
                queryable = queryable.Where(d => d.ToFromLocationId == options.FromLocationId);
            }
            else if (options.FromLocationTypeId != 0)
            {
                queryable = queryable.Where(d => d.ToFromLocation.LocationTypeId == options.FromLocationTypeId);
            }

            if (options.IsClosed != null)
            {
                queryable = queryable.Where(d => d.IsClosed == options.IsClosed);
            }

            return queryable
                .OrderByDescending(d => d.DocumentDate)
                .Select(d => new LocationDeliveryListItemDto
                {
                    DocumentId = d.Id,
                    DocumentNo = d.DocumentNo,
                    ToLocationName = d.Location.Name,
                    FromLocationName = d.ToFromLocation.Name,
                    DocumentDate = d.DocumentDate,
                    StatusName = d.IsClosed ? "Suletud" : "Avatud"
                })
                .GetPagedList(options.CurrentPage, options.PageSize);
        }

        public PagedList<LocationDeliveryListItemDto> ShipmentFilterPage(DeliveryListOptions options)
        {
            var queryable = _context.Documents
                .AsNoTracking()
                .Where(d => d.DocumentType.Code == "SL");

            if (options.FromLocationId != 0)
            {
                queryable = queryable.Where(d => d.LocationId == options.FromLocationId);
            }

            if (options.ToLocationId != 0)
            {
                queryable = queryable.Where(d => d.ToFromLocationId == options.ToLocationId);
            }
            else if (options.ToLocationTypeId != 0)
            {
                queryable = queryable.Where(d => d.ToFromLocation.LocationTypeId == options.ToLocationTypeId);
            }

            if (options.IsClosed != null)
            {
                queryable = queryable.Where(d => d.IsClosed == options.IsClosed);
            }

            return queryable
                .OrderByDescending(d => d.DocumentDate)
                .Select(d => new LocationDeliveryListItemDto
                {
                    DocumentId = d.Id,
                    DocumentNo = d.DocumentNo,
                    FromLocationName = d.Location.Name,
                    ToLocationName = d.ToFromLocation.Name,
                    DocumentDate = d.DocumentDate,
                    StatusName = d.IsClosed ? "Suletud" : "Avatud"
                })
                .GetPagedList(options.CurrentPage, options.PageSize);
        }
    }
}
