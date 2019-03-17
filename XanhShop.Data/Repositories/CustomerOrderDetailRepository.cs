using System.Collections.Generic;
using XanhShop.Data.Infrastructure;
using XanhShop.Model.Models;
using System.Linq;
using System;

namespace XanhShop.Data.Repositories
{
    public interface ICustomerOrderDetailRepository: IRepository<CustomerOrderDetail>
    {
        IEnumerable<CustomerOrderDetail> GenerateListOrderDetailGroupedByProduct();
    }

    public class CustomerOrderDetailRepository : RepositoryBase<CustomerOrderDetail>, ICustomerOrderDetailRepository
    {
        IProductRepository _productRepository;
        public CustomerOrderDetailRepository(IProductRepository productRepository, IDbFactory dbFactory) : base(dbFactory)
        {
            _productRepository = productRepository;
        }

        public IEnumerable<CustomerOrderDetail> GenerateListOrderDetailGroupedByProduct()
        {
            return GetMulti(x => x.CustomerOrder.DateOrdered.Value.Date == DateTime.Now.Date)
                .GroupBy(x => x.ProductID)
                .Select(x => new CustomerOrderDetail() {
                    ProductID = x.Key,
                    Product = _productRepository.GetSingleById(x.Key),
                    Quantity = x.Sum(y => y.Quantity),
                });
        }
    }
}
