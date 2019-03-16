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
        ICustomerOrderRepository _customerOrderRepository;
        ICustomerOrderDetailRepository _customerOrderDetailRepository;
        IUnitOfWork _unitOfWork;
        public SupplierOrderService(ISupplierOrderRepository supplierOrderRepository, ICustomerOrderRepository customerOrderRepository, ICustomerOrderDetailRepository customerOrderDetailRepository, IUnitOfWork unitOfWork)
        {
            _supplierOrderRepository = supplierOrderRepository;
            _customerOrderRepository = customerOrderRepository;
            _customerOrderDetailRepository = customerOrderDetailRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<SupplierOrder> GenerateSupplierOrders()
        {
            List<SupplierOrder> listOrder = new List<SupplierOrder>();
            // var customerOrders = _customerOrderRepository.GetMulti(x => x.DateOrdered.Value.Date == DateTime.Now.Date, new string[] { "CustomerOrderDetails" });
            var customerOrderDetails = _customerOrderDetailRepository.GetMulti(x => x.CustomerOrder.DateOrdered.Value.Date == DateTime.Now.Date, new string[] { "Products", "Suppliers" });
            Dictionary<Product, double> productQuantityDictionary = new Dictionary<Product, double>();
            foreach (var customerOrderDetail in customerOrderDetails)
            {
                if (productQuantityDictionary.ContainsKey(customerOrderDetail.Product))
                {
                    productQuantityDictionary[customerOrderDetail.Product] += customerOrderDetail.Quantity;
                }
                else
                {
                    productQuantityDictionary.Add(customerOrderDetail.Product, customerOrderDetail.Quantity);
                }
            }
            foreach (var productQuantity in productQuantityDictionary)
            {
                if (productQuantity.Key.Suppliers.Count() == 1)
                {
                    SupplierOrder order = new SupplierOrder();
                    
                    listOrder.Add(new SupplierOrder()
                    {
                        SupplierID = productQuantity.Key.Suppliers.FirstOrDefault().ID,
                        SupplierOrderDetails = new List<SupplierOrderDetail>()
                        {

                        }
                    });
                }
            }
            return new List<SupplierOrder>();
        }
    }
}
