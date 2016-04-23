namespace quiendamas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class timechange : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Subastas", "tiempo");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Subastas", "tiempo", c => c.Time(nullable: false, precision: 7));
        }
    }
}
