using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XanhShop.Model.Models;
using XanhShop.Service;
using XanhShop.Web.Extensions;
using XanhShop.Web.Models;

namespace XanhShop.Web.Controllers
{
    public class CartController : Controller
    {
        IProductService _productService;
        ICustomerOrderDetailService _customerOrderDetailService;
        ICustomerOrderService _customerOrderService;
        public CartController(IProductService productService, ICustomerOrderService customerOrderService, ICustomerOrderDetailService customerOrderDetailService)
        {
            _productService = productService;
            _customerOrderService = customerOrderService;
            _customerOrderDetailService = customerOrderDetailService;
        }
        // GET: Cart
        [HttpPost]
        public ActionResult AddToCart(string data)
        {
            var idQuantityPair = data.Split(' ');
            CartDetailViewModel cartDetail = new CartDetailViewModel()
            {
                ProductID = int.Parse(idQuantityPair[0]),
                Quantity = int.Parse(idQuantityPair[1])
            };
            var cart = GetCartFromSession();
            cart.Add(cartDetail);
            Session["Cart"] = cart;
            return Json(new { result = "success" });
        }
        
        public ActionResult CartDetailFromSession()
        {
            var cart = GetCartFromSession();
            foreach (var cartDetail in cart)
            {
                Product dbProduct = _productService.GetById(cartDetail.ProductID);
                cartDetail.ProductName = dbProduct.Name;
                cartDetail.SellPricePerUnit = dbProduct.SellPricePerUnit;
                cartDetail.SellUnit = dbProduct.SellUnit;
            }
            return PartialView(cart);
        }

        public List<CartDetailViewModel> GetCartFromSession()
        {
            List<CartDetailViewModel> cart = Session["Cart"] as List<CartDetailViewModel>;
            if (Session["Cart"] == null)
            {
                cart = new List<CartDetailViewModel>();
                Session["Cart"] = cart;
            }
            return cart;
        }
    }
}