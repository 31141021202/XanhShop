using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XanhShop.Service;
using XanhShop.Web.Extensions;
using XanhShop.Web.Models;

namespace XanhShop.Web.Controllers
{
    public class ProductController : Controller
    {
        IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        
        public ActionResult ProductListAsCart()
        {
            var listProduct = _productService.GetAll();
            List<CartDetailViewModel> listProductCartDetailVm = new List<CartDetailViewModel>();
            foreach (var product in listProduct)
            {
                CartDetailViewModel cartDetailVm = new CartDetailViewModel();
                cartDetailVm.UpdateCartDetail(product);
                listProductCartDetailVm.Add(cartDetailVm);
            }
            return View(listProductCartDetailVm);
        }
    }
}