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
    public interface ISupplierSupplyingCategoryService
    {
        IEnumerable<Supplier> GetSuppliersByCategory(int supplyingCategory);
    }
    public class SupplierSupplyingCategoryService : ISupplierSupplyingCategoryService
    {
        ISupplierSupplyingCategoryRepository _supplierSupplyingCategoryRepository;
        IUnitOfWork _unitOfWork;
        public SupplierSupplyingCategoryService(ISupplierSupplyingCategoryRepository supplierSupplyingCategoryRepository, IUnitOfWork unitOfWork)
        {
            _supplierSupplyingCategoryRepository = supplierSupplyingCategoryRepository;
            _unitOfWork = unitOfWork;
        }

        public IEnumerable<Supplier> GetSuppliersByCategory(int supplyingCategory)
        {
            return _supplierSupplyingCategoryRepository.GetMulti(x => x.SupplyingCategoryID == supplyingCategory).Select(x => x.Supplier);
        }
    }
}
