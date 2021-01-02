using System;
using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Models
{
    public class CustomerAddress
    {
        public int Id { get; set; }

        public int CountryId { get; set; }
        public Country Country { get; set; }

        [MaxLength(30)]
        public string County { get; set; }

        [Required, MaxLength(50)]
        public string City { get; set; }

        [Required, MaxLength(100)]
        public string Address { get; set; }

        [MaxLength(10)]
        public string PostCode { get; set; }

        [MaxLength(50)]
        public string Description { get; set; }

        public bool IsBilling { get; set; }

        public DateTime? CreatedOn { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }


        //--- legacy system fields ---
        public int? FMS_yksusid { get; set; }

        [MaxLength(4)]
        public string FMS_ykood { get; set; }

        [MaxLength(6)]
        public string FMS_skood { get; set; }
    }
}
