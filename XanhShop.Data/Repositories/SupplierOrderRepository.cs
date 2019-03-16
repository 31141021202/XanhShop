using XanhShop.Data.Infrastructure;
using XanhShop.Model.Models;

namespace XanhShop.Data.Repositories
{
    public interface ISupplierOrderRepository : IRepository<SupplierOrder>
    {

    }

    public class SupplierOrderRepository : RepositoryBase<SupplierOrder>, ISupplierOrderRepository
    {
        public SupplierOrderRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
