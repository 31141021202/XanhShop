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
            product.StatusCode = productVm.StatusCode;
        }

        public static void UpdateSupplierOrder(this SupplierOrder supplierOrder, SupplierOrderViewModel supplierOrderVm)
        {
            supplierOrder.ID = supplierOrderVm.ID;
            supplierOrder.SupplierID = supplierOrderVm.SupplierID;
            supplierOrder.DateCreated = supplierOrderVm.DateCreated;
            supplierOrder.Status = supplierOrderVm.Status;
            supplierOrder.AdditionalNote = supplierOrderVm.AdditionalNote;
            supplierOrder.StatusCode = supplierOrder.StatusCode;
        }

        public static void UpdateSupplierOrderDetail(this SupplierOrderDetail supplierOrderDetail, SupplierOrderDetailViewModel supplierOrderDetailVm)
        {
            supplierOrderDetail.SupplierOrderID = supplierOrderDetailVm.SupplierOrderID;
            supplierOrderDetail.ProductID = supplierOrderDetailVm.ProductID;
            supplierOrderDetail.BuyPricePerUnit = supplierOrderDetailVm.BuyPricePerUnit;
            supplierOrderDetail.Quantity = supplierOrderDetailVm.Quantity;
            supplierOrderDetail.StatusCode = supplierOrderDetailVm.StatusCode;
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
            supplier.StatusCode = supplierVm.StatusCode;
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
            productSupplier.StatusCode = productSupplierVm.StatusCode;
        }

        public static void UpdateProductCategory(this ProductCategory productCategory, ProductCategoryViewModel productCategoryVm)
        {
            productCategory.ID = productCategoryVm.ID;
            productCategory.Name = productCategoryVm.Name;
        }

        public static void UpdateCustomerOrderDetail(this CustomerOrderDetail customerOrderDetail, CustomerOrderDetailViewModel customerOrderDetailVm)
        {
            customerOrderDetail.ProductID = customerOrderDetailVm.ProductID;
            customerOrderDetail.CustomerOrderID = customerOrderDetailVm.CustomerOrderID;
            customerOrderDetail.Quantity = customerOrderDetailVm.Quantity;
            customerOrderDetail.SellPricePerUnit = customerOrderDetailVm.SellPricePerUnit;
            customerOrderDetail.StatusCode = customerOrderDetailVm.StatusCode;
            customerOrderDetail.IsModifiedByAdmin = customerOrderDetailVm.IsModifiedByAdmin;
        }

        public static void UpdateCustomerOrder(this CustomerOrder customerOrder, CustomerOrderViewModel customerOrderVm)
        {
            customerOrder.ID = customerOrderVm.ID;
            customerOrder.Address = customerOrderVm.Address;
            customerOrder.PhoneNumber = customerOrderVm.PhoneNumber;
            customerOrder.DateOrdered = customerOrderVm.DateOrdered;
            customerOrder.ReceiveMethod = customerOrderVm.ReceiveMethod;
            customerOrder.PaymentMethod = customerOrderVm.PaymentMethod;
            customerOrder.ShipperID = customerOrderVm.ShipperID;
            customerOrder.CustomerID = customerOrderVm.CustomerID;
            customerOrder.StatusCode = customerOrderVm.StatusCode;
            customerOrder.IsModifiedByAdmin = customerOrderVm.IsModifiedByAdmin;
        }

        public static void UpdateCustomer(this Customer customer, CustomerViewModel customerVm)
        {
            customer.ID = customerVm.ID;
            customer.Name = customerVm.Name;
            customer.Email = customerVm.Email;
            customer.PhoneNumber = customerVm.PhoneNumber;
            customer.Address = customerVm.Address;
        }

        public static void UpdateShipper(this Shipper shipper, ShipperViewModel shipperVm)
        {
            shipper.ID = shipperVm.ID;
            shipper.Name = shipperVm.Name;
            shipper.StatusCode = shipperVm.StatusCode;
        }
    }
}