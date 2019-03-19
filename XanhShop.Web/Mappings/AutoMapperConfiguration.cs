using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using XanhShop.Model.Models;
using XanhShop.Web.Models;

namespace XanhShop.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<ProductCategory, ProductCategoryViewModel>();
                cfg.CreateMap<ProductSupplier, ProductSupplierViewModel>();
                cfg.CreateMap<Product, ProductViewModel>();
                cfg.CreateMap<SupplierOrderDetail, SupplierOrderDetailViewModel>();
                cfg.CreateMap<SupplierOrder, SupplierOrderViewModel>();
                cfg.CreateMap<Supplier, SupplierViewModel>();
            });
        }
    }
}