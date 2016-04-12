namespace quiendamas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate8 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SubastaApplicationUsers",
                c => new
                    {
                        Subasta_subastaID = c.Int(nullable: false),
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Subasta_subastaID, t.ApplicationUser_Id })
                .ForeignKey("dbo.Subastas", t => t.Subasta_subastaID, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .Index(t => t.Subasta_subastaID)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SubastaApplicationUsers", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.SubastaApplicationUsers", "Subasta_subastaID", "dbo.Subastas");
            DropIndex("dbo.SubastaApplicationUsers", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.SubastaApplicationUsers", new[] { "Subasta_subastaID" });
            DropTable("dbo.SubastaApplicationUsers");
        }
    }
}
