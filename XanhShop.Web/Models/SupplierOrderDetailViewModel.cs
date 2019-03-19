using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XanhShop.Web.Models
{
    public class SupplierOrderDetailViewModel
    {
        public int SupplierOrderID { get; set; }

        public int ProductID { get; set; }

        public double Quantity { get; set; }

        public double? BuyPricePerUnit { get; set; }

        public virtual SupplierOrderViewModel SupplierOrder { get; set; }

        public virtual ProductViewModel Product { get; set; }
    }
}