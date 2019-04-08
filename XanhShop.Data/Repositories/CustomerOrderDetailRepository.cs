using System.Collections.Generic;
using XanhShop.Data.Infrastructure;
using XanhShop.Model.Models;
using System.Linq;
using System;
using System.Data.Entity;
using XanhShop.Common;

namespace XanhShop.Data.Repositories
{
    public interface ICustomerOrderDetailRepository: IRepository<CustomerOrderDetail>
    {

    }

    public class CustomerOrderDetailRepository : RepositoryBase<CustomerOrderDetail>, ICustomerOrderDetailRepository
    {
        public CustomerOrderDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
