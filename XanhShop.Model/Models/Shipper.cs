using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using XanhShop.Model.Abstract;

namespace XanhShop.Model.Models
{
    public class Shipper : Status
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [Required]
        [MaxLength(30)]
        public string Name { get; set; }

        public virtual IEnumerable<CustomerOrder> CustomerOrders { get; set; }
    }
}
