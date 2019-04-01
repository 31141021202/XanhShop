using System.Collections.Generic;
using XanhShop.Data.Infrastructure;
using XanhShop.Model.Models;
using System.Linq;
using System;
using System.Data.Entity;
using XanhShop.Common;

namespace XanhShop.Data.Repositories
{
    public interface ICustomerOrderDetailRepository: IRepository<CustomerOrderDetail>
    {
        List<CustomerOrderDetail> GenerateListProcessingOrderDetailGroupedByProduct();
    }

    public class CustomerOrderDetailRepository : RepositoryBase<CustomerOrderDetail>, ICustomerOrderDetailRepository
    {
        IProductRepository _productRepository;
        public CustomerOrderDetailRepository(IProductRepository productRepository, IDbFactory dbFactory) : base(dbFactory)
        {
            _productRepository = productRepository;
        }

        public List<CustomerOrderDetail> GenerateListProcessingOrderDetailGroupedByProduct()
        {
             var listGroupedCustomerOrderDetails = GetMulti(x => x.CustomerOrder.DateOrdered.Value.Day == DateTime.Today.Day
                && x.CustomerOrder.DateOrdered.Value.Month == DateTime.Today.Month
                && x.CustomerOrder.DateOrdered.Value.Year == DateTime.Today.Year
                && x.CustomerOrder.StatusCode == (int)OptionSets.OrderStatusCode.Processing
                && x.Product.ProductCategoryID != (int)OptionSets.ProductCategoryCode.DiverseVegs,
                new string[] { "CustomerOrder", "Product" })
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
