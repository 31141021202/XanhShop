using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XanhShop.Web.Models
{
    public class ProductSupplierViewModel
    {
        public int SupplierID { get; set; }

        public int ProductId { get; set; }

        public virtual SupplierViewModel Supplier { get; set; }

        public virtual ProductViewModel Product { get; set; }

        public string Status { get; set; }

        public string AvailableToHarvestTime { get; set; }

        public double? MaximumQuantity { get; set; }

        public double? MinimumQuantity { get; set; }

        public double BuyPricePerUnit { get; set; }

        public string BuyUnit { get; set; }

        public string Scale { get; set; }
    }
}