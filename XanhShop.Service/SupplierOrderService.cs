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
        IUnitOfWork _unitOfWork;
        public SupplierOrderService(ISupplierOrderRepository supplierOrderRepository, ICustomerOrderDetailRepository customerOrderDetailRepository, IUnitOfWork unitOfWork)
        {
            _supplierOrderRepository = supplierOrderRepository;
            _customerOrderDetailRepository = customerOrderDetailRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<SupplierOrder> GenerateSupplierOrders()
        {
            List<SupplierOrder> listOrder = new List<SupplierOrder>();
            var productQuantityList = _customerOrderDetailRepository.GenerateListOrderDetailGroupedByProduct();

            foreach (var productQuantity in productQuantityList)
            {
                SupplierOrder supplierOrder = new SupplierOrder();
                var countSuppliers = productQuantity.Product.Suppliers.Count();
                for (int i = 1; i <= countSuppliers; i++)
                {
                    supplierOrder.SupplierID = productQuantity.Product.Suppliers.Skip(i - 1).FirstOrDefault().ID;
                    supplierOrder.SupplierOrderDetails = new List<SupplierOrderDetail>()
                        {
                            new SupplierOrderDetail()
                            {
                                ProductID = productQuantity.ProductID,
                                Quantity = productQuantity.Quantity / countSuppliers
                            }
                        };
                    listOrder.Add(supplierOrder);
                }
            }
            return listOrder;
        }
    }
}
