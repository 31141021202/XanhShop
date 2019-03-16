namespace XanhShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CustomerOrderDetails",
                c => new
                    {
                        CustomerOrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                        SellPricePerUnit = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.CustomerOrderID, t.ProductID })
                .ForeignKey("dbo.CustomerOrders", t => t.CustomerOrderID, cascadeDelete: true)
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .Index(t => t.CustomerOrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.CustomerOrders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Address = c.String(maxLength: 500),
                        PhoneNumber = c.String(maxLength: 20),
                        DateOrdered = c.DateTime(),
                        ReceiveMethod = c.String(maxLength: 100),
                        PaymentMethod = c.String(maxLength: 100),
                        Status = c.String(maxLength: 50),
                        ShipperID = c.Int(nullable: false),
                        CustomerID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Customers", t => t.CustomerID, cascadeDelete: true)
                .ForeignKey("dbo.Shippers", t => t.ShipperID, cascadeDelete: true)
                .Index(t => t.ShipperID)
                .Index(t => t.CustomerID);
            
            CreateTable(
                "dbo.Customers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        Email = c.String(nullable: false, maxLength: 50),
                        PhoneNumber = c.String(nullable: false, maxLength: 50),
                        Address = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Shippers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Products",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 256),
                        SellUnit = c.String(nullable: false),
                        SellPricePerUnit = c.Double(nullable: false),
                        Label = c.String(maxLength: 50),
                        InventoryQuantity = c.Double(),
                        Description = c.String(),
                        Images = c.String(maxLength: 500),
                        DiscountPercent = c.Double(),
                        IsOnSell = c.Boolean(),
                        ProductCategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.ProductCategories", t => t.ProductCategoryID, cascadeDelete: true)
                .Index(t => t.ProductCategoryID);
            
            CreateTable(
                "dbo.ProductCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.ProductSuppliers",
                c => new
                    {
                        SupplierID = c.Int(nullable: false),
                        ProductId = c.Int(nullable: false),
                        Status = c.String(maxLength: 50),
                        AvailableToHarvestTime = c.String(maxLength: 50),
                        MaximumQuantity = c.Double(),
                        MinimumQuantity = c.Double(),
                        BuyPricePerUnit = c.Double(nullable: false),
                        BuyUnit = c.String(maxLength: 20),
                        Scale = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => new { t.SupplierID, t.ProductId })
                .ForeignKey("dbo.Products", t => t.ProductId, cascadeDelete: true)
                .ForeignKey("dbo.Suppliers", t => t.SupplierID, cascadeDelete: true)
                .Index(t => t.SupplierID)
                .Index(t => t.ProductId);
            
            CreateTable(
                "dbo.Suppliers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                        Address = c.String(nullable: false, maxLength: 256),
                        PhoneNumber = c.String(nullable: false, maxLength: 20),
                        Email = c.String(nullable: false, maxLength: 50),
                        ProductArrivedTimeAfterOneDay = c.String(maxLength: 50),
                        ProductArrivedLocation = c.String(maxLength: 256),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.SupplierOrderDetails",
                c => new
                    {
                        SupplierOrderID = c.Int(nullable: false),
                        ProductID = c.Int(nullable: false),
                        Quantity = c.Double(nullable: false),
                        BuyPricePerUnit = c.Double(nullable: false),
                    })
                .PrimaryKey(t => new { t.SupplierOrderID, t.ProductID })
                .ForeignKey("dbo.Products", t => t.ProductID, cascadeDelete: true)
                .ForeignKey("dbo.SupplierOrders", t => t.SupplierOrderID, cascadeDelete: true)
                .Index(t => t.SupplierOrderID)
                .Index(t => t.ProductID);
            
            CreateTable(
                "dbo.SupplierOrders",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        SupplierID = c.Int(nullable: false),
                        DateCreated = c.DateTime(),
                        Status = c.String(maxLength: 50),
                        AdditionalNote = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Suppliers", t => t.SupplierID, cascadeDelete: true)
                .Index(t => t.SupplierID);
            
            CreateTable(
                "dbo.SupplierSupplyingCategories",
                c => new
                    {
                        SupplierID = c.Int(nullable: false),
                        SupplyingCategoryID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.SupplierID, t.SupplyingCategoryID })
                .ForeignKey("dbo.Suppliers", t => t.SupplierID, cascadeDelete: true)
                .ForeignKey("dbo.SupplyingCategories", t => t.SupplyingCategoryID, cascadeDelete: true)
                .Index(t => t.SupplierID)
                .Index(t => t.SupplyingCategoryID);
            
            CreateTable(
                "dbo.SupplyingCategories",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SupplierSupplyingCategories", "SupplyingCategoryID", "dbo.SupplyingCategories");
            DropForeignKey("dbo.SupplierSupplyingCategories", "SupplierID", "dbo.Suppliers");
            DropForeignKey("dbo.SupplierOrderDetails", "SupplierOrderID", "dbo.SupplierOrders");
            DropForeignKey("dbo.SupplierOrders", "SupplierID", "dbo.Suppliers");
            DropForeignKey("dbo.SupplierOrderDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.ProductSuppliers", "SupplierID", "dbo.Suppliers");
            DropForeignKey("dbo.ProductSuppliers", "ProductId", "dbo.Products");
            DropForeignKey("dbo.CustomerOrderDetails", "ProductID", "dbo.Products");
            DropForeignKey("dbo.Products", "ProductCategoryID", "dbo.ProductCategories");
            DropForeignKey("dbo.CustomerOrderDetails", "CustomerOrderID", "dbo.CustomerOrders");
            DropForeignKey("dbo.CustomerOrders", "ShipperID", "dbo.Shippers");
            DropForeignKey("dbo.CustomerOrders", "CustomerID", "dbo.Customers");
            DropIndex("dbo.SupplierSupplyingCategories", new[] { "SupplyingCategoryID" });
            DropIndex("dbo.SupplierSupplyingCategories", new[] { "SupplierID" });
            DropIndex("dbo.SupplierOrders", new[] { "SupplierID" });
            DropIndex("dbo.SupplierOrderDetails", new[] { "ProductID" });
            DropIndex("dbo.SupplierOrderDetails", new[] { "SupplierOrderID" });
            DropIndex("dbo.ProductSuppliers", new[] { "ProductId" });
            DropIndex("dbo.ProductSuppliers", new[] { "SupplierID" });
            DropIndex("dbo.Products", new[] { "ProductCategoryID" });
            DropIndex("dbo.CustomerOrders", new[] { "CustomerID" });
            DropIndex("dbo.CustomerOrders", new[] { "ShipperID" });
            DropIndex("dbo.CustomerOrderDetails", new[] { "ProductID" });
            DropIndex("dbo.CustomerOrderDetails", new[] { "CustomerOrderID" });
            DropTable("dbo.SupplyingCategories");
            DropTable("dbo.SupplierSupplyingCategories");
            DropTable("dbo.SupplierOrders");
            DropTable("dbo.SupplierOrderDetails");
            DropTable("dbo.Suppliers");
            DropTable("dbo.ProductSuppliers");
            DropTable("dbo.ProductCategories");
            DropTable("dbo.Products");
            DropTable("dbo.Shippers");
            DropTable("dbo.Customers");
            DropTable("dbo.CustomerOrders");
            DropTable("dbo.CustomerOrderDetails");
        }
    }
}
