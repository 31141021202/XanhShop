using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XanhShop.Model.Models
{
    public class CustomerOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [MaxLength(500)]
        public string Address { get; set; }

        [MaxLength(20)]
        public string PhoneNumber { get; set; }

        public DateTime? DateOrdered { get; set; }

        [MaxLength(100)]
        public string ReceiveMethod { get; set; }

        [MaxLength(100)]
        public string PaymentMethod { get; set; }
        
        [MaxLength(50)]
        public string Status { get; set; }

        public int ShipperID { get; set; }

        [ForeignKey("ShipperID")]
        public virtual Shipper Shipper {get; set; }

        public int CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }

        public virtual IEnumerable<CustomerOrderDetail> GetCustomerOrderDetails { get; set; }
    }
}
