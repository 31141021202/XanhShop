using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Script.Serialization;
using XanhShop.Common;
using XanhShop.Model.Models;
using XanhShop.Service;
using XanhShop.Web.Extensions;
using XanhShop.Web.Models;

namespace XanhShop.Web.Controllers
{
    public class SupplierController : Controller
    {
        ISupplierSupplyingCategoryService _supplierSupplyingCategoryService;
        IProductSupplierService _productSupplierService;
        public SupplierController(ISupplierSupplyingCategoryService supplierSupplyingCategoryService, IProductSupplierService productSupplierService)
        {
            _supplierSupplyingCategoryService = supplierSupplyingCategoryService;
            _productSupplierService = productSupplierService;
        }
        
        [HttpGet]
        public ActionResult GetSuppliersByCategory(int id)
        {
            var listSuppliers = _supplierSupplyingCategoryService.GetSuppliersByCategory(id);
            List<SupplierViewModel> listSupVm = new List<SupplierViewModel>();
            foreach (var sup in listSuppliers)
            {
                SupplierViewModel supplierVm = Mapper.Map<SupplierViewModel>(sup);
                var bagOfVegsInfo = _productSupplierService.GetBagOfVegsInfoBySupplier(sup.ID);
                supplierVm.MaximumQuantity = bagOfVegsInfo.MaximumQuantity;
                supplierVm.MinimumQuantity = bagOfVegsInfo.MinimumQuantity;
                supplierVm.Scale = bagOfVegsInfo.Scale;
                listSupVm.Add(supplierVm);
            }
            return PartialView(listSupVm);
        }
    }
}