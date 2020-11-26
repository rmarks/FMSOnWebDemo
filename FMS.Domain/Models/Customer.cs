using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace FMS.Domain.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        [Required]
        [MaxLength(70)]
        public string Name { get; set; }

        [Required]
        [MaxLength(20)]
        public string RegNo { get; set; }

        [MaxLength(20)]
        public string VATNo { get; set; }

        public int PaymentTermId { get; set; }
        public PaymentTerm PaymentTerm { get; set; }

        [MaxLength(50)]
        public string DeliveryTermText { get; set; }

        public int FixedDiscountPercent { get; set; }
        
        public bool IsVAT { get; set; }

        public DateTime CreatedOn { get; set; }

        public List<CustomerAddress> Addresses { get; set; } = new List<CustomerAddress>();
        public List<CustomerContact> Contacts { get; set; } = new List<CustomerContact>();


        //temp
        public CustomerAddress PayerAddress => Addresses.FirstOrDefault(a => a.IsBilling);


        //legacy system fields
        public int? FMS_yksusid { get; set; }

        [MaxLength(4)]
        public string FMS_ykood { get; set; }
    }
}
