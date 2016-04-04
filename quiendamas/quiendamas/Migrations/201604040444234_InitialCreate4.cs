namespace quiendamas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate4 : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Pujas", name: "ApplicationUser_Id", newName: "id");
            RenameIndex(table: "dbo.Pujas", name: "IX_ApplicationUser_Id", newName: "IX_id");
            DropColumn("dbo.Pujas", "UserID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pujas", "UserID", c => c.String());
            RenameIndex(table: "dbo.Pujas", name: "IX_id", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Pujas", name: "id", newName: "ApplicationUser_Id");
        }
    }
}
