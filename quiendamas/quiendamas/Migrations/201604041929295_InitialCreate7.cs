namespace quiendamas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate7 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Pujas", name: "ApplicationUser_Id", newName: "Id");
            RenameIndex(table: "dbo.Pujas", name: "IX_ApplicationUser_Id", newName: "IX_Id");
            AddColumn("dbo.Subastas", "tiempo", c => c.Time(nullable: false, precision: 7));
            DropColumn("dbo.Pujas", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pujas", "UserID", c => c.String());
            DropColumn("dbo.Subastas", "tiempo");
            RenameIndex(table: "dbo.Pujas", name: "IX_Id", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Pujas", name: "Id", newName: "ApplicationUser_Id");
        }
    }
}
