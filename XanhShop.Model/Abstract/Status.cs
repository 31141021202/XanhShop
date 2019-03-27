using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XanhShop.Model.Models;

namespace XanhShop.Model.Abstract
{
    public abstract class Status
    {
        public int? StatusCode { get; set; }

        [ForeignKey("StatusCode")]
        public virtual StatusCodeMap StatusCodeMap { get; set; }
    }
}
