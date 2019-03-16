using XanhShop.Data.Infrastructure;
using XanhShop.Model.Models;

namespace XanhShop.Data.Repositories
{
    public interface ISupplierSupplyingCategoryRepository : IRepository<SupplierSupplyingCategory>
    {

    }

    public class SupplierSupplyingCategoryRepository : RepositoryBase<SupplierSupplyingCategory>, ISupplierSupplyingCategoryRepository
    {
        public SupplierSupplyingCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
