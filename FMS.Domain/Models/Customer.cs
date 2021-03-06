﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace FMS.Domain.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required, MaxLength(70)]
        public string Name { get; set; }

        [Required, MaxLength(20)]
        
        public string RegNo { get; set; }

        [MaxLength(20)]
        public string VATNo { get; set; }

        public int PaymentDays { get; set; }
        
        [MaxLength(50)]
        public string DeliveryTermText { get; set; }

        public int FixedDiscountPercent { get; set; }

        public bool IsVAT { get; set; }

        public bool HasCommissionLocation { get; set; }

        public DateTime? CreatedOn { get; set; }

        public List<CustomerAddress> Addresses { get; set; } = new List<CustomerAddress>();
        public List<CustomerContact> Contacts { get; set; } = new List<CustomerContact>();


        //temp
        private CustomerAddress payerAddress;
        [NotMapped]
        public CustomerAddress PayerAddress
        {
            get
            {
                if (payerAddress == null)
                {
                    payerAddress = Addresses.FirstOrDefault(a => a.IsBilling) ?? new CustomerAddress { IsBilling = true, Country = new Country() };
                }

                return payerAddress;
            }
        }

        [NotMapped]
        public List<CustomerAddress> ConsigneeAddresses => Addresses.Where(a => !a.IsBilling).ToList() ?? new List<CustomerAddress>();


        //legacy system fields
        public int? FMS_yksusid { get; set; }

        [MaxLength(4)]
        public string FMS_ykood { get; set; }
    }
}
