using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XanhShop.Web.Models
{
    public class CustomerOrderViewModel
    {
        [Display(Name = "Mã")]
        public int ID { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Điện thoại")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Ngày đặt")]
        public DateTime? DateOrdered { get; set; }

        public string ReceiveMethod { get; set; }

        public string PaymentMethod { get; set; }

        public int? ShipperID { get; set; }

        public virtual ShipperViewModel Shipper { get; set; }

        public int? CustomerID { get; set; }

        public virtual CustomerViewModel Customer { get; set; }

        public virtual IEnumerable<CustomerOrderDetailViewModel> CustomerOrderDetails { get; set; }

        [Display(Name = "Trạng thái")]
        public int StatusCode { get; set; }

        public StatusCodeMapViewModel StatusCodeMap { get; set; }

        public bool? IsModifiedByAdmin { get; set; } = false;
    }
}