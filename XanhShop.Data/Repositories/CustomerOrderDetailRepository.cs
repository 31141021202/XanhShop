using System.Collections.Generic;
using XanhShop.Data.Infrastructure;
using XanhShop.Model.Models;
using System.Linq;
using System;
using System.Data.Entity;

namespace XanhShop.Data.Repositories
{
    public interface ICustomerOrderDetailRepository: IRepository<CustomerOrderDetail>
    {
        List<CustomerOrderDetail> GenerateListOrderDetailGroupedByProduct();
    }

    public class CustomerOrderDetailRepository : RepositoryBase<CustomerOrderDetail>, ICustomerOrderDetailRepository
    {
        IProductRepository _productRepository;
        public CustomerOrderDetailRepository(IProductRepository productRepository, IDbFactory dbFactory) : base(dbFactory)
        {
            _productRepository = productRepository;
        }

        public List<CustomerOrderDetail> GenerateListOrderDetailGroupedByProduct()
        {
             var listGroupedCustomerOrderDetails = GetMulti(x => x.CustomerOrder.DateOrdered.Value.Day == DateTime.Today.Day
                && x.CustomerOrder.DateOrdered.Value.Month == DateTime.Today.Month
                && x.CustomerOrder.DateOrdered.Value.Year == DateTime.Today.Year,
                new string[] { "CustomerOrder" })
                .GroupBy(x => x.ProductID)
                .Select(x => new CustomerOrderDetail() {
                    ProductID = x.Key,
                    Quantity = x.Sum(y => y.Quantity),
                })
                .ToList();
            return listGroupedCustomerOrderDetails;
        }
    }
}
