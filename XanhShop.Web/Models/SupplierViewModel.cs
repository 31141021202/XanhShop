using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace XanhShop.Web.Models
{
    public class SupplierViewModel
    {
        [Display(Name = "Mã")]
        public int ID { get; set; }

        [Display(Name = "Tên nhà cung ứng")]
        public string Name { get; set; }

        [Display(Name = "Địa chỉ")]
        public string Address { get; set; }

        [Display(Name = "Số lượng")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Email")]
        public string Email { get; set; }

        public string ProductArrivedTimeAfterOneDay { get; set; }

        public string ProductArrivedLocation { get; set; }

        public virtual IEnumerable<ProductSupplierViewModel> ProductSuppliers { get; set; }

        public virtual IEnumerable<SupplierOrderViewModel> SupplierOrders { get; set; }

        [Display(Name = "Trạng thái")]
        public int StatusCode { get; set; }

        public StatusCodeMapViewModel StatusCodeMap { get; set; }

        [Display(Name = "Số lượng tối đa / ngày")]
        public double? MaximumQuantity { get; set; }

        [Display(Name = "Số lượng tối thiểu / ngày")]
        public double? MinimumQuantity { get; set; }

        [Display(Name = "Quy mô")]
        public string Scale { get; set; }

    }
}