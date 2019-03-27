using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XanhShop.Model.Models;

namespace XanhShop.Data
{
    public class XanhShopDbContext : DbContext
    {
        public XanhShopDbContext() : base("XanhShopConnection")
        {
            Configuration.LazyLoadingEnabled = false;
        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CustomerOrder> CustomerOrders { get; set; }
        public DbSet<CustomerOrderDetail> CustomerOrderDetails { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCategory> ProductCategories { get; set; }
        public DbSet<ProductSupplier> ProductSuppliers { get; set; }
        public DbSet<Shipper> Shippers { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }
        public DbSet<SupplierOrder> SupplierOrders { get; set; }
        public DbSet<SupplierOrderDetail> SupplierOrderDetails { get; set; }
        public DbSet<SupplierSupplyingCategory> SupplierSupplyingCategories { get; set; }
        public DbSet<SupplyingCategory> SupplyingCategories { get; set; }
        public DbSet<StatusCodeMap> StatusCodeMaps { get; set; }

        public static XanhShopDbContext Create()
        {
            return new XanhShopDbContext();
        }
    }
}
