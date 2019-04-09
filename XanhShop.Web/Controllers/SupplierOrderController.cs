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
        ICustomerOrderService _customerOrderService;
        ICustomerOrderDetailService _customerOrderDetailService;
        IProductService _productService;
        public SupplierOrderController(ISupplierOrderService supplierOrderService,
            ISupplierOrderDetailService supplierOrderDetailService,
            ICustomerOrderService customerOrderService,
            ICustomerOrderDetailService customerOrderDetailService,
            IProductService productService)
        {
            _supplierOrderService = supplierOrderService;
            _supplierOrderDetailService = supplierOrderDetailService;
            _customerOrderService = customerOrderService;
            _customerOrderDetailService = customerOrderDetailService;
            _productService = productService;
        }
        // GET: SupplierOrder
        public ActionResult Index()
        {
            var dbSupplierOrder = _supplierOrderService.GetAll();
            List<SupplierOrderViewModel> supplierOrders = new List<SupplierOrderViewModel>();
            foreach (var dbOrder in dbSupplierOrder)
            {
                var supplierOrderVm = Mapper.Map<SupplierOrderViewModel>(dbOrder);
                supplierOrders.Add(supplierOrderVm);
            }
            return View(supplierOrders);
        }

        [HttpPost]
        public ActionResult Create(SupplierOrder supplierOrder)
        {
            return Json(new { result = "success", data = supplierOrder });
        }

        [HttpGet]
        public ActionResult GenerateSupplierOrders()
        {
            var generatedSupplierOrders = _supplierOrderService.GenerateSupplierOrders();
            var relatedCustomerOrder = _customerOrderService.GetCurrentProcessingCustomerOrder();
            List<int> relatedCustomerOrderIds = new List<int>();
            foreach (var order in relatedCustomerOrder)
            {
                relatedCustomerOrderIds.Add(order.ID);
            }
            return Json(new { data = generatedSupplierOrders, customerOrderIds = relatedCustomerOrderIds }, JsonRequestBehavior.AllowGet);
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