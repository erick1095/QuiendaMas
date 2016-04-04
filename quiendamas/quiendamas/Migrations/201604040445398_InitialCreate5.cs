namespace quiendamas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate5 : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Pujas", new[] { "id" });
            CreateIndex("dbo.Pujas", "Id");
        }
        
        public override void Down()
        {
            DropIndex("dbo.Pujas", new[] { "Id" });
            CreateIndex("dbo.Pujas", "id");
        }
    }
}
