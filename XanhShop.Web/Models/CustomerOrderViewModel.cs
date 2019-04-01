using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XanhShop.Web.Models
{
    public class CustomerOrderViewModel
    {
        public int ID { get; set; }

        public string Address { get; set; }

        public string PhoneNumber { get; set; }

        public DateTime? DateOrdered { get; set; }

        public string ReceiveMethod { get; set; }

        public string PaymentMethod { get; set; }

        public int? ShipperID { get; set; }

        public virtual ShipperViewModel Shipper { get; set; }

        public int? CustomerID { get; set; }

        public virtual CustomerViewModel Customer { get; set; }

        public virtual IEnumerable<CustomerOrderDetailViewModel> CustomerOrderDetails { get; set; }

        public int StatusCode { get; set; }

        public StatusCodeMapViewModel StatusCodeMap { get; set; }

        public bool? IsModifiedByAdmin { get; set; } = false;
    }
}