namespace quiendamas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate9 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.SubastaApplicationUsers", "Subasta_subastaID", "dbo.Subastas");
            DropForeignKey("dbo.SubastaApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.SubastaApplicationUsers", new[] { "Subasta_subastaID" });
            DropIndex("dbo.SubastaApplicationUsers", new[] { "ApplicationUser_Id" });
            DropTable("dbo.SubastaApplicationUsers");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.SubastaApplicationUsers",
                c => new
                    {
                        Subasta_subastaID = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Subasta_subastaID, t.ApplicationUser_Id });
            
            CreateIndex("dbo.SubastaApplicationUsers", "ApplicationUser_Id");
            CreateIndex("dbo.SubastaApplicationUsers", "Subasta_subastaID");
            AddForeignKey("dbo.SubastaApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.SubastaApplicationUsers", "Subasta_subastaID", "dbo.Subastas", "subastaID", cascadeDelete: true);
        }
    }
}
