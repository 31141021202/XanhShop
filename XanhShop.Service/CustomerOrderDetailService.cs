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
    public interface ICustomerOrderDetailService
    {
        
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

        
    }
}
