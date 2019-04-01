using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XanhShop.Common;
using XanhShop.Data.Infrastructure;
using XanhShop.Data.Repositories;
using XanhShop.Model.Models;

namespace XanhShop.Service
{
    public interface ISupplierOrderService
    {
        IEnumerable<SupplierOrder> GetAll();
        IEnumerable<SupplierOrder> GenerateSupplierOrders();
        SupplierOrder Add(SupplierOrder order);
        void Save();

    }
    public class SupplierOrderService : ISupplierOrderService
    {
        ISupplierOrderRepository _supplierOrderRepository;
        ICustomerOrderDetailRepository _customerOrderDetailRepository;
        IProductSupplierRepository _productSupplierRepository;
        IStatusCodeMapRepository _statusCodeMapRepository;
        IUnitOfWork _unitOfWork;
        public SupplierOrderService(ISupplierOrderRepository supplierOrderRepository, IProductSupplierRepository productSupplierRepository, ICustomerOrderDetailRepository customerOrderDetailRepository, IStatusCodeMapRepository statusCodeMapRepository, IUnitOfWork unitOfWork)
        {
            _supplierOrderRepository = supplierOrderRepository;
            _customerOrderDetailRepository = customerOrderDetailRepository;
            _productSupplierRepository = productSupplierRepository;
            _statusCodeMapRepository = statusCodeMapRepository;
            _unitOfWork = unitOfWork;
        }

        public SupplierOrder Add(SupplierOrder order)
        {
            return _supplierOrderRepository.Add(order);
        }

        public IEnumerable<SupplierOrder> GenerateSupplierOrders()
        {
            List<SupplierOrder> listOrder = new List<SupplierOrder>();
            var productQuantityList = _customerOrderDetailRepository.GenerateListProcessingOrderDetailGroupedByProduct();

            foreach (var productQuantity in productQuantityList)
            {
                
                var productSuppliers = _productSupplierRepository.GetMulti(x => x.ProductId == productQuantity.ProductID, new string[] { "Product", "Supplier" });
                foreach (var productSupplier in productSuppliers)
                {
                    SupplierOrder supplierOrder = new SupplierOrder();
                    supplierOrder.SupplierID = productSupplier.SupplierID;
                    supplierOrder.Supplier = productSupplier.Supplier;
                    supplierOrder.StatusCode = (int)OptionSets.OrderStatusCode.Processing;
                    supplierOrder.StatusCodeMap = _statusCodeMapRepository.GetStatusLabel((int)OptionSets.OrderStatusCode.Processing);
                    supplierOrder.SupplierOrderDetails = new List<SupplierOrderDetail>()
                        {
                            new SupplierOrderDetail()
                            {
                                ProductID = productQuantity.ProductID,
                                Product = productSupplier.Product,
                                Quantity = productQuantity.Quantity / productSuppliers.Count(),
                                BuyPricePerUnit = productSupplier.BuyPricePerUnit
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

        public IEnumerable<SupplierOrder> GetAll()
        {
            return _supplierOrderRepository.GetAll();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
