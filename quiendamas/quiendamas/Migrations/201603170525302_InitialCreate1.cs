namespace quiendamas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.ApplicationUserSubastas", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserSubastas", "Subasta_subastaID", "dbo.Subastas");
            DropForeignKey("dbo.Articuloes", "userID", "dbo.AspNetUsers");
            DropIndex("dbo.Articuloes", new[] { "userID" });
            DropIndex("dbo.ApplicationUserSubastas", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.ApplicationUserSubastas", new[] { "Subasta_subastaID" });
            CreateTable(
                "dbo.Pujas",
                c => new
                    {
                        pujaID = c.Int(nullable: false, identity: true),
                        cantidadParticipaciones = c.Int(nullable: false),
                        fechaPuja = c.DateTime(nullable: false),
                        subastaID = c.Int(nullable: false),
                        UserID = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.pujaID)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id)
                .ForeignKey("dbo.Subastas", t => t.subastaID, cascadeDelete: true)
                .Index(t => t.subastaID)
                .Index(t => t.ApplicationUser_Id);
            
            AddColumn("dbo.Articuloes", "ApplicationUser_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Articuloes", "UserID", c => c.String());
            CreateIndex("dbo.Articuloes", "ApplicationUser_Id");
            AddForeignKey("dbo.Articuloes", "ApplicationUser_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Subastas", "cantidadParticipaciones");
            DropTable("dbo.ApplicationUserSubastas");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.ApplicationUserSubastas",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Subasta_subastaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Subasta_subastaID });
            
            AddColumn("dbo.Subastas", "cantidadParticipaciones", c => c.Int(nullable: false));
            DropForeignKey("dbo.Articuloes", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Pujas", "subastaID", "dbo.Subastas");
            DropForeignKey("dbo.Pujas", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Pujas", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.Pujas", new[] { "subastaID" });
            DropIndex("dbo.Articuloes", new[] { "ApplicationUser_Id" });
            AlterColumn("dbo.Articuloes", "UserID", c => c.String(maxLength: 128));
            DropColumn("dbo.Articuloes", "ApplicationUser_Id");
            DropTable("dbo.Pujas");
            CreateIndex("dbo.ApplicationUserSubastas", "Subasta_subastaID");
            CreateIndex("dbo.ApplicationUserSubastas", "ApplicationUser_Id");
            CreateIndex("dbo.Articuloes", "userID");
            AddForeignKey("dbo.Articuloes", "userID", "dbo.AspNetUsers", "Id");
            AddForeignKey("dbo.ApplicationUserSubastas", "Subasta_subastaID", "dbo.Subastas", "subastaID", cascadeDelete: true);
            AddForeignKey("dbo.ApplicationUserSubastas", "ApplicationUser_Id", "dbo.AspNetUsers", "Id", cascadeDelete: true);
        }
    }
}
