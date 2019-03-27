using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XanhShop.Web.Models
{
    [Serializable]
    public class ProductViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string SellUnit { get; set; }

        public double SellPricePerUnit { get; set; }

        public string Label { get; set; }

        public double? InventoryQuantity { get; set; }

        public string Description { get; set; }

        public string Images { get; set; }

        public double? DiscountPercent { get; set; }

        public bool? IsOnSell { get; set; }

        public int ProductCategoryID { get; set; }

        public virtual ProductCategoryViewModel ProductCategory { get; set; }

        public virtual IEnumerable<ProductSupplierViewModel> ProductSuppliers { get; set; }
    }
}