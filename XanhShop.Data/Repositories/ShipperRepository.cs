using XanhShop.Data.Infrastructure;
using XanhShop.Model.Models;

namespace XanhShop.Data.Repositories
{
    public interface IShipperRepository : IRepository<Shipper>
    {

    }

    public class ShipperRepository : RepositoryBase<Shipper>, IShipperRepository
    {
        public ShipperRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }
}
