using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XanhShop.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private XanhShopDbContext dbContext;
        public XanhShopDbContext Init()
        {
            return dbContext ?? (dbContext = new XanhShopDbContext());
        }
        
        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
