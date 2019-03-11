using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XanhShop.Model.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(256)]
        public string Name { get; set; }

        [Required]
        public string SellUnit { get; set; }

        [Required]
        public double SellPricePerUnit { get; set; }

        [MaxLength(50)]
        public string Label { get; set; }

        public double? InventoryQuantity { get; set; }

        [MaxLength]
        public string Description { get; set; }

        [MaxLength(500)]
        public string Images { get; set; }

        public double? DiscountPercent { get; set; }

        public bool? IsOnSell { get; set; }

        public int ProductCategoryID { get; set; }

        [ForeignKey("ProductCategoryID")]
        public virtual ProductCategory ProductCategory { get; set; } 

        public virtual IEnumerable<Supplier> Suppliers { get; set; }
    }
}
