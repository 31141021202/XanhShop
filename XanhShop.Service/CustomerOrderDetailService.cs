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
    public interface ICustomerOrderDetailService
    {
        IEnumerable<CustomerOrderDetail> GetCustomerOrderDetailByProduct(int productId);
        void Update(CustomerOrderDetail customerOrderDetail);
        CustomerOrderDetail GetSingleOrderDetail(int productID, int customerID);
        CustomerOrderDetail Add(CustomerOrderDetail entity);
        double GetTotalBagOfVegQuantity();
        void Save();
    }
    public class CustomerOrderDetailService : ICustomerOrderDetailService
    {
        ICustomerOrderDetailRepository _customerOrderDetailRepository;
        IUnitOfWork _unitOfWork;
        public CustomerOrderDetailService(ICustomerOrderDetailRepository customerOrderDetailRepository, IUnitOfWork unitOfWork)
        {
            _customerOrderDetailRepository = customerOrderDetailRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<CustomerOrderDetail> GetCustomerOrderDetailByProduct(int productId)
        {
            return _customerOrderDetailRepository.GetMulti(x => x.ProductID == productId
                && x.StatusCode == (int)OptionSets.OrderStatusCode.Processing);
        }

        public CustomerOrderDetail GetSingleOrderDetail(int productID, int customerID)
        {
            return _customerOrderDetailRepository.GetMulti(x => x.ProductID == productID && x.CustomerOrderID == customerID).FirstOrDefault();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(CustomerOrderDetail customerOrderDetail)
        {
            _customerOrderDetailRepository.Update(customerOrderDetail);
        }

        public double GetTotalBagOfVegQuantity()
        {
            var listCustomerOrderDetailBagOfVegs = _customerOrderDetailRepository.GetMulti(x => x.CustomerOrder.DateOrdered.Value.Day == DateTime.Today.Day
                && x.CustomerOrder.DateOrdered.Value.Month == DateTime.Today.Month
                && x.CustomerOrder.DateOrdered.Value.Year == DateTime.Today.Year
                && x.CustomerOrder.StatusCode == (int)OptionSets.OrderStatusCode.Processing
                && x.Product.ProductCategoryID == (int)OptionSets.ProductCategoryCode.DiverseVegs);
            return listCustomerOrderDetailBagOfVegs.Sum(x => x.Quantity);
        }

        public CustomerOrderDetail Add(CustomerOrderDetail entity)
        {
            return _customerOrderDetailRepository.Add(entity);
        }
    }
}
