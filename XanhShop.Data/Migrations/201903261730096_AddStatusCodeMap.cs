namespace XanhShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddStatusCodeMap : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.StatusCodeMaps",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Name = c.String(maxLength: 100),
                    })
                .PrimaryKey(t => t.ID);
            
            AddColumn("dbo.CustomerOrderDetails", "StatusCode", c => c.Int());
            AddColumn("dbo.CustomerOrders", "StatusCode", c => c.Int());
            AddColumn("dbo.Shippers", "StatusCode", c => c.Int());
            AddColumn("dbo.Products", "StatusCode", c => c.Int());
            AddColumn("dbo.ProductSuppliers", "StatusCode", c => c.Int());
            AddColumn("dbo.Suppliers", "StatusCode", c => c.Int());
            AddColumn("dbo.SupplierOrderDetails", "StatusCode", c => c.Int());
            AddColumn("dbo.SupplierOrders", "StatusCode", c => c.Int());
            CreateIndex("dbo.CustomerOrderDetails", "StatusCode");
            CreateIndex("dbo.CustomerOrders", "StatusCode");
            CreateIndex("dbo.Shippers", "StatusCode");
            CreateIndex("dbo.Products", "StatusCode");
            CreateIndex("dbo.ProductSuppliers", "StatusCode");
            CreateIndex("dbo.Suppliers", "StatusCode");
            CreateIndex("dbo.SupplierOrderDetails", "StatusCode");
            CreateIndex("dbo.SupplierOrders", "StatusCode");
            AddForeignKey("dbo.Shippers", "StatusCode", "dbo.StatusCodeMaps", "ID");
            AddForeignKey("dbo.CustomerOrders", "StatusCode", "dbo.StatusCodeMaps", "ID");
            AddForeignKey("dbo.Products", "StatusCode", "dbo.StatusCodeMaps", "ID");
            AddForeignKey("dbo.CustomerOrderDetails", "StatusCode", "dbo.StatusCodeMaps", "ID");
            AddForeignKey("dbo.ProductSuppliers", "StatusCode", "dbo.StatusCodeMaps", "ID");
            AddForeignKey("dbo.Suppliers", "StatusCode", "dbo.StatusCodeMaps", "ID");
            AddForeignKey("dbo.SupplierOrderDetails", "StatusCode", "dbo.StatusCodeMaps", "ID");
            AddForeignKey("dbo.SupplierOrders", "StatusCode", "dbo.StatusCodeMaps", "ID");
            DropColumn("dbo.CustomerOrders", "Status");
        }
        
        public override void Down()
        {
            AddColumn("dbo.CustomerOrders", "Status", c => c.String(maxLength: 50));
            DropForeignKey("dbo.SupplierOrders", "StatusCode", "dbo.StatusCodeMaps");
            DropForeignKey("dbo.SupplierOrderDetails", "StatusCode", "dbo.StatusCodeMaps");
            DropForeignKey("dbo.Suppliers", "StatusCode", "dbo.StatusCodeMaps");
            DropForeignKey("dbo.ProductSuppliers", "StatusCode", "dbo.StatusCodeMaps");
            DropForeignKey("dbo.CustomerOrderDetails", "StatusCode", "dbo.StatusCodeMaps");
            DropForeignKey("dbo.Products", "StatusCode", "dbo.StatusCodeMaps");
            DropForeignKey("dbo.CustomerOrders", "StatusCode", "dbo.StatusCodeMaps");
            DropForeignKey("dbo.Shippers", "StatusCode", "dbo.StatusCodeMaps");
            DropIndex("dbo.SupplierOrders", new[] { "StatusCode" });
            DropIndex("dbo.SupplierOrderDetails", new[] { "StatusCode" });
            DropIndex("dbo.Suppliers", new[] { "StatusCode" });
            DropIndex("dbo.ProductSuppliers", new[] { "StatusCode" });
            DropIndex("dbo.Products", new[] { "StatusCode" });
            DropIndex("dbo.Shippers", new[] { "StatusCode" });
            DropIndex("dbo.CustomerOrders", new[] { "StatusCode" });
            DropIndex("dbo.CustomerOrderDetails", new[] { "StatusCode" });
            DropColumn("dbo.SupplierOrders", "StatusCode");
            DropColumn("dbo.SupplierOrderDetails", "StatusCode");
            DropColumn("dbo.Suppliers", "StatusCode");
            DropColumn("dbo.ProductSuppliers", "StatusCode");
            DropColumn("dbo.Products", "StatusCode");
            DropColumn("dbo.Shippers", "StatusCode");
            DropColumn("dbo.CustomerOrders", "StatusCode");
            DropColumn("dbo.CustomerOrderDetails", "StatusCode");
            DropTable("dbo.StatusCodeMaps");
        }
    }
}
