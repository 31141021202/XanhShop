namespace XanhShop.Web.Models
{
    public class CustomerOrderDetailViewModel
    {
        public int CustomerOrderID { get; set; }

        public int ProductID { get; set; }

        public double Quantity { get; set; }

        public double? SellPricePerUnit { get; set; }

        public virtual CustomerOrderViewModel CustomerOrder { get; set; }

        public virtual ProductViewModel Product { get; set; }

        public int StatusCode { get; set; }

        public StatusCodeMapViewModel StatusCodeMap { get; set; }

        public bool? IsModifiedByAdmin { get; set; } = false;
    }
}