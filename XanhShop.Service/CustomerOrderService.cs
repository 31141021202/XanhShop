using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using XanhShop.Common;
using XanhShop.Data.Infrastructure;
using XanhShop.Data.Repositories;
using XanhShop.Model.Models;

namespace XanhShop.Service
{
    public interface ICustomerOrderService
    {
        CustomerOrder Add(CustomerOrder customerOrder);
        CustomerOrder Delete(int id);
        void Update(CustomerOrder customerOrder);
        IEnumerable<CustomerOrder> GetMany(Expression<Func<CustomerOrder, bool>> where, string[] includes);
        CustomerOrder GetSingleById(int id);
        void Save();
    }
    public class CustomerOrderService : ICustomerOrderService
    {
        ICustomerOrderRepository _customerOrderRepository;
        ICustomerOrderDetailRepository _customerOrderDetailRepository;
        IUnitOfWork _unitOfWork;
        public CustomerOrderService(ICustomerOrderRepository customerOrderRepository, ICustomerOrderDetailRepository customerOrderDetailRepository, IUnitOfWork unitOfWork)
        {
            _customerOrderRepository = customerOrderRepository;
            _customerOrderDetailRepository = customerOrderDetailRepository;
            _unitOfWork = unitOfWork;
        }

        public CustomerOrder Add(CustomerOrder customerOrder)
        {
            throw new NotImplementedException();
        }

        public CustomerOrder Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<CustomerOrder> GetMany(Expression<Func<CustomerOrder, bool>> where, string[] includes)
        {
            throw new NotImplementedException();
        }

        public CustomerOrder GetSingleById(int id)
        {
            return _customerOrderRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(CustomerOrder customerOrder)
        {
            _customerOrderRepository.Update(customerOrder);
        }

        
    }
}
