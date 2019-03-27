using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using XanhShop.Model.Abstract;

namespace XanhShop.Model.Models
{
    public class CustomerOrderDetail : Status
    {
        [Key]
        [Column(Order = 1)]
        public int CustomerOrderID { get; set; }

        [Key]
        [Column(Order = 2)]
        public int ProductID { get; set; }

        public double Quantity { get; set; }

        public double? SellPricePerUnit { get; set; }

        [ForeignKey("CustomerOrderID")]
        public virtual CustomerOrder CustomerOrder { get; set; }

        [ForeignKey("ProductID")]
        public virtual Product Product { get; set; }
    }
}
