namespace XanhShop.Data.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using XanhShop.Model.Models;

    internal sealed class Configuration : DbMigrationsConfiguration<XanhShop.Data.XanhShopDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(XanhShop.Data.XanhShopDbContext context)
        {
            // CreateStatusCodeMap(context);
            // CreateProductCategorySample(context);
            // CreateProductSample(context);
            // CreateSupplierSample(context);
            // CreateProductSupplierSample(context);
            // CreateCustomerOrderSample(context);
            // CreateCustomerOrderDetailSample(context);
            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.
        }

        private void CreateProductCategorySample(XanhShopDbContext context)
        {
            if (context.ProductCategories.Count() == 0)
            {
                List<ProductCategory> listProductCategory = new List<ProductCategory>()
                {
                    new ProductCategory() { Name = "Rau cu qua" },
                    new ProductCategory() { Name = "Thit" }
                };
                context.ProductCategories.AddRange(listProductCategory);
                context.SaveChanges();
            }
        }

        private void CreateProductSample(XanhShopDbContext context)
        {
            if (context.Products.Count() == 0)
            {
                List<Product> listProduct = new List<Product>()
                {
                    new Product() { Name = "Rau lang", SellPricePerUnit = 25000, SellUnit = "kg", ProductCategoryID = 1 },
                    new Product() { Name = "Rau mong toi", SellPricePerUnit = 25000, SellUnit = "kg", ProductCategoryID = 1 },
                    new Product() { Name = "Thit bo", SellPricePerUnit = 50000, SellUnit = "kg", ProductCategoryID = 2 },
                    new Product() { Name = "Bap chuoi", SellPricePerUnit = 20000, SellUnit = "kg", ProductCategoryID = 1 }
                };
                context.Products.AddRange(listProduct);
                context.SaveChanges();
            }
        }

        private void CreateSupplierSample(XanhShopDbContext context)
        {
            if (context.Suppliers.Count() == 0)
            {
                List<Supplier> listSupplier = new List<Supplier>()
                {
                    new Supplier() { Name = "Nha cung ung 1", Address = "Sample address", PhoneNumber = "0000000", Email = "Sample email" },
                    new Supplier() { Name = "Nha cung ung 2", Address = "Sample address", PhoneNumber = "0000000", Email = "Sample email" },
                    new Supplier() { Name = "Nha cung ung 3", Address = "Sample address", PhoneNumber = "0000000", Email = "Sample email" },
                    new Supplier() { Name = "Nha cung ung 4", Address = "Sample address", PhoneNumber = "0000000", Email = "Sample email" },
                };
                context.Suppliers.AddRange(listSupplier);
                context.SaveChanges();
            }
        }

        private void CreateProductSupplierSample(XanhShopDbContext context)
        {
            if (context.ProductSuppliers.Count() == 0)
            {
                List<ProductSupplier> listProductSupplier = new List<ProductSupplier>()
                {
                    new ProductSupplier() { ProductId = 6, SupplierID = 2, BuyPricePerUnit = 15000, BuyUnit = "kg" },
                    new ProductSupplier() { ProductId = 6, SupplierID = 3, BuyPricePerUnit = 20000, BuyUnit = "kg" },
                    new ProductSupplier() { ProductId = 6, SupplierID = 1, BuyPricePerUnit = 35000, BuyUnit = "kg" },
                    new ProductSupplier() { ProductId = 7, SupplierID = 1, BuyPricePerUnit = 50000, BuyUnit = "kg" },
                    new ProductSupplier() { ProductId = 8, SupplierID = 3, BuyPricePerUnit = 50000, BuyUnit = "kg" },
                    new ProductSupplier() { ProductId = 8, SupplierID = 4, BuyPricePerUnit = 50000, BuyUnit = "kg" },
                    new ProductSupplier() { ProductId = 9, SupplierID = 2, BuyPricePerUnit = 55000, BuyUnit = "kg" },
                };
                context.ProductSuppliers.AddRange(listProductSupplier);
                context.SaveChanges();
            }
        }

        private void CreateCustomerOrderSample(XanhShopDbContext context)
        {
            if (context.CustomerOrders.Count() == 0)
            {
                List<CustomerOrder> listCustomerOrder = new List<CustomerOrder>()
                {
                    new CustomerOrder() { DateOrdered = DateTime.Now },
                    new CustomerOrder() { DateOrdered = DateTime.Now },
                    new CustomerOrder() { DateOrdered = DateTime.Now },
                    new CustomerOrder() { DateOrdered = DateTime.Now },
                    new CustomerOrder() { DateOrdered = DateTime.Now },
                };
                context.CustomerOrders.AddRange(listCustomerOrder);
                context.SaveChanges();
            }
        }

        private void CreateCustomerOrderDetailSample(XanhShopDbContext context)
        {
            if (context.CustomerOrderDetails.Count() == 0)
            {
                List<CustomerOrderDetail> listCustomerOrderDetail = new List<CustomerOrderDetail>()
                {
                    new CustomerOrderDetail() { CustomerOrderID = 1, ProductID = 6, Quantity = 2 },
                    new CustomerOrderDetail() { CustomerOrderID = 1, ProductID = 7, Quantity = 3 },
                    new CustomerOrderDetail() { CustomerOrderID = 2, ProductID = 8, Quantity = 1 },
                    new CustomerOrderDetail() { CustomerOrderID = 2, ProductID = 9, Quantity = 2 },
                    new CustomerOrderDetail() { CustomerOrderID = 3, ProductID = 7, Quantity = 4 },
                    new CustomerOrderDetail() { CustomerOrderID = 3, ProductID = 8, Quantity = 3 },
                    new CustomerOrderDetail() { CustomerOrderID = 3, ProductID = 9, Quantity = 5 },
                    new CustomerOrderDetail() { CustomerOrderID = 4, ProductID = 6, Quantity = 1 },
                    new CustomerOrderDetail() { CustomerOrderID = 5, ProductID = 9, Quantity = 2 },
                };
                context.CustomerOrderDetails.AddRange(listCustomerOrderDetail);
                context.SaveChanges();
            }
        }

        private void CreateStatusCodeMap(XanhShopDbContext context)
        {
            if (context.StatusCodeMaps.Count() == 0)
            {
                List<StatusCodeMap> listStatusCodeMap = new List<StatusCodeMap>()
                {
                    new StatusCodeMap() { ID = 1, Name = "Đang xử lý" },
                    new StatusCodeMap() { ID = 2, Name = "Đã đặt" }, 
                    new StatusCodeMap() { ID = 3, Name = "Đang chờ nhận hàng" },
                    new StatusCodeMap() { ID = 4, Name = "Đang duyệt hàng" },
                    new StatusCodeMap() { ID = 5, Name = "Hoàn tất" },
                    new StatusCodeMap() { ID = 9, Name = "Hủy" },
                    new StatusCodeMap() { ID = 13, Name = "Hàng bị hỏng" }
                };
                context.StatusCodeMaps.AddRange(listStatusCodeMap);
                context.SaveChanges();
            }
        }
    }
}
