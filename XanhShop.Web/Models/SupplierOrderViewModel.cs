using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XanhShop.Web.Models
{
    public class SupplierOrderViewModel
    {
        public int ID { get; set; }

        public int SupplierID { get; set; }

        public virtual SupplierViewModel Supplier { get; set; }

        public DateTime? DateCreated { get; set; }

        public string Status { get; set; }

        public string AdditionalNote { get; set; }

        public virtual IEnumerable<SupplierOrderDetailViewModel> SupplierOrderDetails { get; set; }
    }
}