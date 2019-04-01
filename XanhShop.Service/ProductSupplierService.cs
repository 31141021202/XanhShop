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
    public interface IProductSupplierService
    {
        ProductSupplier GetBagOfVegsInfoBySupplier(int supplierId);
        void Save();
    }
    public class ProductSupplierService : IProductSupplierService
    {
        IProductSupplierRepository _productSupplierRepository;
        IUnitOfWork _unitOfWork;
        public ProductSupplierService(IProductSupplierRepository productSupplierRepository, IUnitOfWork unitOfWork)
        {
            _productSupplierRepository = productSupplierRepository;
            _unitOfWork = unitOfWork;
        }

        public ProductSupplier GetBagOfVegsInfoBySupplier(int supplierId)
        {
            return _productSupplierRepository.GetMulti(x => x.SupplierID == supplierId
                && x.Product.ProductCategoryID == (int)OptionSets.ProductCategoryCode.DiverseVegs)
                .FirstOrDefault();
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }
    }
}
