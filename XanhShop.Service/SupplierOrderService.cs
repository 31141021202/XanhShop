using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XanhShop.Data.Infrastructure;
using XanhShop.Data.Repositories;
using XanhShop.Model.Models;

namespace XanhShop.Service
{
    public interface ISupplierOrderService
    {
        IEnumerable<SupplierOrder> GenerateSupplierOrders();
    }
    public class SupplierOrderService : ISupplierOrderService
    {
        ISupplierOrderRepository _supplierOrderRepository;
        ICustomerOrderDetailRepository _customerOrderDetailRepository;
        IProductSupplierRepository _productSupplierRepository;
        IUnitOfWork _unitOfWork;
        public SupplierOrderService(ISupplierOrderRepository supplierOrderRepository, IProductSupplierRepository productSupplierRepository, ICustomerOrderDetailRepository customerOrderDetailRepository, IUnitOfWork unitOfWork)
        {
            _supplierOrderRepository = supplierOrderRepository;
            _customerOrderDetailRepository = customerOrderDetailRepository;
            _productSupplierRepository = productSupplierRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<SupplierOrder> GenerateSupplierOrders()
        {
            List<SupplierOrder> listOrder = new List<SupplierOrder>();
            var productQuantityList = _customerOrderDetailRepository.GenerateListOrderDetailGroupedByProduct();

            foreach (var productQuantity in productQuantityList)
            {
                SupplierOrder supplierOrder = new SupplierOrder();
                var productSuppliers = _productSupplierRepository.GetMulti(x => x.ProductId == productQuantity.ProductID, new string[] { "Product", "Supplier" });
                foreach (var productSupplier in productSuppliers)
                {
                    supplierOrder.SupplierID = productSupplier.SupplierID;
                    supplierOrder.Supplier = productSupplier.Supplier;
                    supplierOrder.SupplierOrderDetails = new List<SupplierOrderDetail>()
                        {
                            new SupplierOrderDetail()
                            {
                                ProductID = productQuantity.ProductID,
                                Product = productSupplier.Product,
                                Quantity = productQuantity.Quantity / productSuppliers.Count(),
                                // BuyPricePerUnit = productSupplier.BuyPricePerUnit
                            }
                        };
                    listOrder.Add(supplierOrder);
                }
            }

            listOrder = listOrder.GroupBy(x => x.SupplierID).Select(x => new SupplierOrder() { 
                SupplierID = x.Key,
                SupplierOrderDetails = x.Select(y => y.SupplierOrderDetails).Aggregate((a,b) => a.Concat(b)),
                Supplier = x.Select(y => y.Supplier).FirstOrDefault(),
            }).ToList();

            return listOrder;
        }
    }
}
