namespace ModernStore.Infra.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class v4 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderItem", "Product_Id", "dbo.Product");
            DropIndex("dbo.OrderItem", new[] { "Product_Id" });
            AddColumn("dbo.OrderItem", "Product", c => c.Guid(nullable: false));
            DropColumn("dbo.OrderItem", "Product_Id");
        }
        
        public override void Down()
        {
            AddColumn("dbo.OrderItem", "Product_Id", c => c.Guid(nullable: false));
            DropColumn("dbo.OrderItem", "Product");
            CreateIndex("dbo.OrderItem", "Product_Id");
            AddForeignKey("dbo.OrderItem", "Product_Id", "dbo.Product", "Id", cascadeDelete: true);
        }
    }
}
