using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XanhShop.Model.Models
{
    public class SupplierOrderDetail
    {
        [Key]
        [Column(Order = 1)]
        public int SupplierOrderID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ProductID { get; set; }

        public double Quantity { get; set; }

        public double? BuyPricePerUnit { get; set; }

        [ForeignKey("SupplierOrderID")]
        public virtual SupplierOrder SupplierOrder { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}
