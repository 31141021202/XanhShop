using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using XanhShop.Model.Abstract;

namespace XanhShop.Model.Models
{
    public class CustomerOrder : Status
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

        public int? ShipperID { get; set; }

        [ForeignKey("ShipperID")]
        public virtual Shipper Shipper {get; set; }

        public int? CustomerID { get; set; }

        [ForeignKey("CustomerID")]
        public virtual Customer Customer { get; set; }

        public virtual IEnumerable<CustomerOrderDetail> CustomerOrderDetails { get; set; }

        public bool? IsModifiedByAdmin { get; set; } = false;
    } 
}
