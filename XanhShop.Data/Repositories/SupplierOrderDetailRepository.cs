using XanhShop.Data.Infrastructure;
using XanhShop.Model.Models;

namespace XanhShop.Data.Repositories
{
    public interface ISupplierOrderDetailRepository : IRepository<SupplierOrderDetail>
    {

    }

    public class SupplierOrderDetailRepository : RepositoryBase<SupplierOrderDetail>, ISupplierOrderDetailRepository
    {
        public SupplierOrderDetailRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}


