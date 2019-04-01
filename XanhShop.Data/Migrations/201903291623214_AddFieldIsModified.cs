namespace XanhShop.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddFieldIsModified : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.CustomerOrderDetails", "IsModifiedByAdmin", c => c.Boolean());
            AddColumn("dbo.CustomerOrders", "IsModifiedByAdmin", c => c.Boolean());
        }
        
        public override void Down()
        {
            DropColumn("dbo.CustomerOrders", "IsModifiedByAdmin");
            DropColumn("dbo.CustomerOrderDetails", "IsModifiedByAdmin");
        }
    }
}
