using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using XanhShop.Model.Abstract;

namespace XanhShop.Model.Models
{
    public class ProductSupplier : Status
    {
        [Key]
        [Column(Order = 1)]
        public int SupplierID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ProductId { get; set; }

        [ForeignKey("SupplierID")]
        public virtual Supplier Supplier { get; set; }

        [ForeignKey("ProductId")]
        public virtual Product Product { get; set; }

        [MaxLength(50)]
        public string Status { get; set; }

        [MaxLength(50)]
        public string AvailableToHarvestTime { get; set; }

        public double? MaximumQuantity { get; set; }

        public double? MinimumQuantity { get; set; }

        [Required]
        public double BuyPricePerUnit { get; set; }

        [MaxLength(20)]
        public string BuyUnit { get; set; }

        [MaxLength(50)]
        public string Scale { get; set; }
    }
}
