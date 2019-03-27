﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using XanhShop.Model.Abstract;

namespace XanhShop.Model.Models
{
    public class Supplier : Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        [MaxLength(256)]
        public string Address { get; set; }

        [Required]
        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        [MaxLength(50)]
        public string Email { get; set; }

        [MaxLength(50)]
        public string ProductArrivedTimeAfterOneDay { get; set; }

        [MaxLength(256)]
        public string ProductArrivedLocation { get; set; }

        public virtual IEnumerable<ProductSupplier> ProductSuppliers { get; set; }

        public virtual IEnumerable<SupplierOrder> SupplierOrders { get; set; }

        public virtual IEnumerable<SupplyingCategory> SupplyingCategories { get; set; }
    }
}
