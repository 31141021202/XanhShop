using XanhShop.Data.Infrastructure;
using XanhShop.Model.Models;

namespace XanhShop.Data.Repositories
{
    public interface IProductSupplierRepository : IRepository<ProductSupplier>
    {

    }

    public class ProductSupplierRepository : RepositoryBase<ProductSupplier>, IProductSupplierRepository
    {
        public ProductSupplierRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
