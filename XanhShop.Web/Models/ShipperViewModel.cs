using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XanhShop.Web.Models
{
    public class ShipperViewModel
    {
        public int ID { get; set; }

        public string Name { get; set; }

        public virtual IEnumerable<CustomerOrderViewModel> CustomerOrders { get; set; }

        public int StatusCode { get; set; }

        public StatusCodeMapViewModel StatusCodeMap { get; set; }
    }
}