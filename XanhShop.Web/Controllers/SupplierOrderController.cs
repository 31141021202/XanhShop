using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XanhShop.Model.Models;
using XanhShop.Service;
using XanhShop.Web.Models;

namespace XanhShop.Web.Controllers
{
    public class SupplierOrderController : Controller
    {
        ISupplierOrderService _supplierOrderService;
        public SupplierOrderController(ISupplierOrderService supplierOrderService)
        {
            _supplierOrderService = supplierOrderService;
        }
        // GET: SupplierOrder
        public ActionResult Index()
        {
            var dbSupplierOrder = _supplierOrderService.GetAll();
            var supplierOrders = Mapper.Map<List<SupplierOrderViewModel>>(dbSupplierOrder);
            return View(supplierOrders);
        }

        [HttpPost]
        public ActionResult Create(SupplierOrder supplierOrder)
        {
            return Json(new { result = "success", data = supplierOrder });
        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Update(SupplierOrder supplierOrder)
        {
            return View();
        }

        [HttpGet]
        public ActionResult GenerateSupplierOrders()
        {
            return Json(new { data = _supplierOrderService.GenerateSupplierOrders() }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetGeneratedSupplierOrders()
        {
            return View();
        }
    }
}