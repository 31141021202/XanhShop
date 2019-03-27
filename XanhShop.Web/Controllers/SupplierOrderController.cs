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
    public class SupplierOrderController : Controller
    {
        ISupplierOrderService _supplierOrderService;
        ISupplierOrderDetailService _supplierOrderDetailService;
        public SupplierOrderController(ISupplierOrderService supplierOrderService, ISupplierOrderDetailService supplierOrderDetailService)
        {
            _supplierOrderService = supplierOrderService;
            _supplierOrderDetailService = supplierOrderDetailService;
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

        [HttpPost]
        public ActionResult CreateSupplierOrders(string orders)
        {
            var listOrder = JsonConvert.DeserializeObject<List<SupplierOrderViewModel>>(orders);
            foreach (var order in listOrder)
            {
                SupplierOrder dbOrder = new SupplierOrder();
                dbOrder.SupplierID = order.SupplierID;
                dbOrder.DateCreated = DateTime.Now;
                dbOrder.StatusCode = (int)OptionSets.OrderStatusCode.AwaitingReceive;
                _supplierOrderService.Add(dbOrder);
                _supplierOrderService.Save();

                foreach (var orderDetails in order.SupplierOrderDetails)
                {
                    SupplierOrderDetail supplierOrderDetail = new SupplierOrderDetail();
                    orderDetails.SupplierOrderID = dbOrder.ID;
                    supplierOrderDetail.UpdateSupplierOrderDetail(orderDetails);
                    _supplierOrderDetailService.Add(supplierOrderDetail);
                    _supplierOrderDetailService.Save();
                }
            }
            return RedirectToAction("GetGeneratedSupplierOrders");
        }
    }
}