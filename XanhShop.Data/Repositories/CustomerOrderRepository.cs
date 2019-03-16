using XanhShop.Data.Infrastructure;
using XanhShop.Model.Models;

namespace XanhShop.Data.Repositories
{
    public interface ICustomerOrderRepository : IRepository<CustomerOrder>
    {

    }

    public class CustomerOrderRepository : RepositoryBase<CustomerOrder>, ICustomerOrderRepository
    {
        public CustomerOrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
