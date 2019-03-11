using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace XanhShop.Model.Models
{
    public class SupplierOrder
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        public int SupplierID { get; set; }

        [ForeignKey("SupplierID")]
        public virtual Supplier Supplier { get; set; }

        public DateTime? DateCreated { get; set; }

        [MaxLength(50)]
        public string Status { get; set; }

        [MaxLength]
        public string AdditionalNote { get; set; }

        public virtual IEnumerable<SupplierOrderDetail> GetSupplierOrderDetails { get; set; }
    }
}
