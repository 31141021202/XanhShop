using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XanhShop.Model.Models
{
    public class SupplierSupplyingCategory
    {
        [Key]
        [Column(Order = 1)]
        public int SupplierID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int SupplyingCategoryID { get; set; }

        [ForeignKey("SupplierID")]
        public virtual Supplier Supplier { get; set; }

        [ForeignKey("SupplyingCategoryID")]
        public virtual SupplyingCategory SupplyingCategory { get; set; }
    }
}
