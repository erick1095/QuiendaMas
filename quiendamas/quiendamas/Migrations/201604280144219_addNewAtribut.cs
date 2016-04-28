namespace quiendamas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNewAtribut : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "cantToken", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "cantToken");
        }
    }
}
