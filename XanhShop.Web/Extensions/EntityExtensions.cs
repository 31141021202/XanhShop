using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using XanhShop.Model.Models;
using XanhShop.Web.Models;

namespace XanhShop.Web.Extensions
{
    public static class EntityExtensions
    {
        public static void UpdateProduct(this Product product, ProductViewModel productVm)
        {
            product.ID = productVm.ID;
            product.Name = productVm.Name;
            product.SellUnit = productVm.SellUnit;
            product.SellPricePerUnit = productVm.SellPricePerUnit;
            product.Label = productVm.Label;
            product.InventoryQuantity = productVm.InventoryQuantity;
            product.Description = productVm.Description;
            product.Images = productVm.Images;
            product.DiscountPercent = productVm.DiscountPercent;
            product.IsOnSell = productVm.IsOnSell;
            product.ProductCategoryID = productVm.ProductCategoryID;
        }

        public static void UpdateSupplierOrder(this SupplierOrder supplierOrder, SupplierOrderViewModel supplierOrderVm)
        {
            supplierOrder.ID = supplierOrderVm.ID;
            supplierOrder.SupplierID = supplierOrderVm.SupplierID;
            supplierOrder.DateCreated = supplierOrderVm.DateCreated;
            supplierOrder.Status = supplierOrderVm.Status;
            supplierOrder.AdditionalNote = supplierOrderVm.AdditionalNote;
        }

        public static void UpdateSupplierOrderDetail(this SupplierOrderDetail supplierOrderDetail, SupplierOrderDetailViewModel supplierOrderDetailVm)
        {
            supplierOrderDetail.SupplierOrderID = supplierOrderDetailVm.SupplierOrderID;
            supplierOrderDetail.ProductID = supplierOrderDetailVm.ProductID;
            supplierOrderDetail.BuyPricePerUnit = supplierOrderDetailVm.BuyPricePerUnit;
            supplierOrderDetail.Quantity = supplierOrderDetailVm.Quantity;
        }

        public static void UpdateSupplier(this Supplier supplier, SupplierViewModel supplierVm)
        {
            supplier.ID = supplierVm.ID;
            supplier.Name = supplierVm.Name;
            supplier.Address = supplierVm.Address;
            supplier.PhoneNumber = supplierVm.PhoneNumber;
            supplier.Email = supplierVm.Email;
            supplier.ProductArrivedTimeAfterOneDay = supplierVm.ProductArrivedTimeAfterOneDay;
            supplier.ProductArrivedLocation = supplierVm.ProductArrivedLocation;
        }

        public static void UpdateProductSupplier(this ProductSupplier productSupplier, ProductSupplierViewModel productSupplierVm)
        {
            productSupplier.SupplierID = productSupplierVm.SupplierID;
            productSupplier.ProductId = productSupplierVm.ProductId;
            productSupplier.Status = productSupplierVm.Status;
            productSupplier.AvailableToHarvestTime = productSupplierVm.AvailableToHarvestTime;
            productSupplier.MaximumQuantity = productSupplierVm.MaximumQuantity;
            productSupplier.MinimumQuantity = productSupplierVm.MinimumQuantity;
            productSupplier.BuyPricePerUnit = productSupplierVm.BuyPricePerUnit;
            productSupplier.BuyUnit = productSupplierVm.BuyUnit;
            productSupplier.Scale = productSupplierVm.Scale;
        }

        public static void UpdateProductCategory(this ProductCategory productCategory, ProductCategoryViewModel productCategoryVm)
        {
            productCategory.ID = productCategoryVm.ID;
            productCategory.Name = productCategoryVm.Name;
        }
    }
}