using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XanhShop.Web.Models
{
    public class SupplierViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }
        
        public string Email { get; set; }

        public string ProductArrivedTimeAfterOneDay { get; set; }

        public string ProductArrivedLocation { get; set; }

        public virtual IEnumerable<ProductSupplierViewModel> ProductSuppliers { get; set; }

        public virtual IEnumerable<SupplierOrderViewModel> SupplierOrders { get; set; }

        public int StatusCode { get; set; }

        public StatusCodeMapViewModel StatusCodeMap { get; set; }

        public double? MaximumQuantity { get; set; }

        public double? MinimumQuantity { get; set; }

        public string Scale { get; set; }

    }
}