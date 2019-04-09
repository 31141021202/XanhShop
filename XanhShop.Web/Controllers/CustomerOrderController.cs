﻿using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XanhShop.Common;
using XanhShop.Model.Models;
using XanhShop.Service;
using XanhShop.Web.Extensions;
using XanhShop.Web.Models;

namespace XanhShop.Web.Controllers
{
    public class CustomerOrderController : Controller
    {
        ICustomerOrderDetailService _customerOrderDetailService;
        ICustomerOrderService _customerOrderService;
        IProductService _productService;

        public CustomerOrderController(IProductService productService, ICustomerOrderDetailService customerOrderDetailService, ICustomerOrderService customerOrderService)
        {
            _customerOrderDetailService = customerOrderDetailService;
            _productService = productService;
            _customerOrderService = customerOrderService;
        }

        // GET: CustomerOrder
        public ActionResult Index()
        {
            var customerOrder = _customerOrderService.GetProcessingCustomerOrder();
            List<CustomerOrderViewModel> listCustomerModelVm = new List<CustomerOrderViewModel>();
            foreach (var order in customerOrder)
            {
                CustomerOrderViewModel customerOrderVm = Mapper.Map<CustomerOrderViewModel>(order);
                listCustomerModelVm.Add(customerOrderVm);
            }
            return View(listCustomerModelVm);
        }

        public ActionResult GetRelatedCustomerOrderDetailByProduct(int id)
        {
            var listCustomerOrderDetailByProduct = _customerOrderDetailService.GetCustomerOrderDetailByProduct(id);
            return View(listCustomerOrderDetailByProduct.OrderBy(x => x.CustomerOrder.DateOrdered));
        }

        [HttpPost]
        public ActionResult UpdateQuantity(string data)
        {
            var target = JsonConvert.DeserializeObject<CustomerOrderDetailViewModel>(data);

            var dbOrderDetail = _customerOrderDetailService.GetSingleOrderDetail(target.ProductID, target.CustomerOrderID);
            dbOrderDetail.Quantity = target.Quantity;
            dbOrderDetail.IsModifiedByAdmin = true;
            _customerOrderDetailService.Update(dbOrderDetail);
            _customerOrderDetailService.Save();

            var dbOrder = _customerOrderService.GetSingleById(target.CustomerOrderID);
            dbOrder.IsModifiedByAdmin = true;
            _customerOrderService.Update(dbOrder);
            _customerOrderService.Save();

            return Json(new { result = "success" });
        }

        [HttpPost]
        public ActionResult UpdateGeneratedOrderStatus(string data)
        {
            var target = JsonConvert.DeserializeObject<List<int>>(data);

            foreach (int id in target)
            {
                var dbOrder = _customerOrderService.GetSingleById(id);
                dbOrder.StatusCode = (int)OptionSets.OrderStatusCode.Validating;
                _customerOrderService.Update(dbOrder);
                _customerOrderService.Save();
            }

            return Json(new { result = "success" });
        }

        [HttpGet]
        public ActionResult SummarizeBagsOfVeg()
        {
            var sumQuantity = _customerOrderDetailService.GetTotalBagOfVegQuantity();
            return Json(new { total = sumQuantity }, JsonRequestBehavior.AllowGet);
        }
    }
}