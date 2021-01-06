﻿using System;
using System.ComponentModel.DataAnnotations;

namespace FMS.Domain.Models
{
    public class DeliveryDomain
    {
        public int Id { get; set; }
        
        [Required, MaxLength(1)]
        public string Code { get; set; }
        
        [Required, MaxLength(30)]
        public string Name { get; set; }
        
        public DateTime? CreatedOn { get; set; }
    }
}
