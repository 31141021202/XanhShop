using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XanhShop.Web.Models
{
    [Serializable]
    public class SupplierOrderViewModel
    {
        [Display(Name = "Mã")]
        public int ID { get; set; }

        [Display(Name = "Mã nhà cung ứng")]
        public int SupplierID { get; set; }

        [Display(Name = "Tên nhà cung ứng")]
        public virtual SupplierViewModel Supplier { get; set; }

        [Display(Name = "Ngày tạo")]
        public DateTime? DateCreated { get; set; }

        public string Status { get; set; }

        [Display(Name = "Ghi chú")]
        public string AdditionalNote { get; set; }

        public virtual IEnumerable<SupplierOrderDetailViewModel> SupplierOrderDetails { get; set; }

        [Display(Name = "Trạng thái")]
        public int StatusCode { get; set; }

        public StatusCodeMapViewModel StatusCodeMap { get; set; }
    }
}