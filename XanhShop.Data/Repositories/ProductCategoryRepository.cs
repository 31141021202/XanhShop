using XanhShop.Data.Infrastructure;
using XanhShop.Model.Models;

namespace XanhShop.Data.Repositories
{
    public interface IProductCategoryRepository : IRepository<ProductCategory>
    {

    }

    public class ProductCategoryRepository : RepositoryBase<ProductCategory>, IProductCategoryRepository
    {
        public ProductCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
