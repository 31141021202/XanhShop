using XanhShop.Data.Infrastructure;
using XanhShop.Model.Models;

namespace XanhShop.Data.Repositories
{
    public interface ISupplyingCategoryRepository : IRepository<SupplyingCategory>
    {

    }

    public class SupplyingCategoryRepository : RepositoryBase<SupplyingCategory>, ISupplyingCategoryRepository
    {
        public SupplyingCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
