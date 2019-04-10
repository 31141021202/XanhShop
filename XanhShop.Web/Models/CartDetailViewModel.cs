using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace XanhShop.Web.Models
{
    public class CartDetailViewModel
    {
        [Display(Name = "Mã sản phẩm")]
        public int ProductID { get; set; }

        [Display(Name = "Tên sản phẩm")]
        public string ProductName { get; set; }

        [Display(Name = "Đơn vị")]
        public string SellUnit { get; set; }

        [Display(Name = "Đơn giá")]
        public double SellPricePerUnit { get; set; }

        [Display(Name = "Số lượng")]
        public double Quantity { get; set; }
    }
}