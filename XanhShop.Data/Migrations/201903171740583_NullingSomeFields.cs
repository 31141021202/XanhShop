namespace XanhShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NullingSomeFields : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.CustomerOrders", "CustomerID", "dbo.Customers");
            DropForeignKey("dbo.CustomerOrders", "ShipperID", "dbo.Shippers");
            DropIndex("dbo.CustomerOrders", new[] { "ShipperID" });
            DropIndex("dbo.CustomerOrders", new[] { "CustomerID" });
            AlterColumn("dbo.CustomerOrderDetails", "SellPricePerUnit", c => c.Double());
            AlterColumn("dbo.CustomerOrders", "ShipperID", c => c.Int());
            AlterColumn("dbo.CustomerOrders", "CustomerID", c => c.Int());
            AlterColumn("dbo.SupplierOrderDetails", "BuyPricePerUnit", c => c.Double());
            CreateIndex("dbo.CustomerOrders", "ShipperID");
            CreateIndex("dbo.CustomerOrders", "CustomerID");
            AddForeignKey("dbo.CustomerOrders", "CustomerID", "dbo.Customers", "ID");
            AddForeignKey("dbo.CustomerOrders", "ShipperID", "dbo.Shippers", "ID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.CustomerOrders", "ShipperID", "dbo.Shippers");
            DropForeignKey("dbo.CustomerOrders", "CustomerID", "dbo.Customers");
            DropIndex("dbo.CustomerOrders", new[] { "CustomerID" });
            DropIndex("dbo.CustomerOrders", new[] { "ShipperID" });
            AlterColumn("dbo.SupplierOrderDetails", "BuyPricePerUnit", c => c.Double(nullable: false));
            AlterColumn("dbo.CustomerOrders", "CustomerID", c => c.Int(nullable: false));
            AlterColumn("dbo.CustomerOrders", "ShipperID", c => c.Int(nullable: false));
            AlterColumn("dbo.CustomerOrderDetails", "SellPricePerUnit", c => c.Double(nullable: false));
            CreateIndex("dbo.CustomerOrders", "CustomerID");
            CreateIndex("dbo.CustomerOrders", "ShipperID");
            AddForeignKey("dbo.CustomerOrders", "ShipperID", "dbo.Shippers", "ID", cascadeDelete: true);
            AddForeignKey("dbo.CustomerOrders", "CustomerID", "dbo.Customers", "ID", cascadeDelete: true);
        }
    }
}
