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
    public interface ISupplierOrderDetailService
    {
        SupplierOrderDetail Add(SupplierOrderDetail supplierOrderDetail);
        void Save();
    }

    public class SupplierOrderDetailService : ISupplierOrderDetailService
    {
        ISupplierOrderDetailRepository _supplierOrderDetailRepository;
        IUnitOfWork _unitOfWork;
        public SupplierOrderDetailService(ISupplierOrderDetailRepository supplierOrderDetailRepository, IUnitOfWork unitOfWork)
        {
            _supplierOrderDetailRepository = supplierOrderDetailRepository;
            _unitOfWork = unitOfWork;
        }
        public SupplierOrderDetail Add(SupplierOrderDetail supplierOrderDetail)
        {
            return _supplierOrderDetailRepository.Add(supplierOrderDetail);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
