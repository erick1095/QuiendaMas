namespace quiendamas.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Articuloes",
                c => new
                    {
                        articuloID = c.Int(nullable: false, identity: true),
                        nombre = c.String(),
                        estadoArticulo = c.String(),
                        costo = c.Decimal(nullable: false, precision: 18, scale: 2),
                        descripcion = c.String(),
                        userID = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.articuloID)
                .ForeignKey("dbo.AspNetUsers", t => t.userID)
                .Index(t => t.userID);
            
            CreateTable(
                "dbo.Subastas",
                c => new
                    {
                        subastaID = c.Int(nullable: false, identity: true),
                        cantidadParticipaciones = c.Int(nullable: false),
                        estado = c.Boolean(nullable: false),
                        fechaInicio = c.DateTime(nullable: false),
                        fechaFin = c.DateTime(nullable: false),
                        ganador = c.String(),
                        articuloID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.subastaID)
                .ForeignKey("dbo.Articuloes", t => t.articuloID, cascadeDelete: true)
                .Index(t => t.articuloID);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        nombre = c.String(),
                        apellido = c.String(),
                        colonia = c.String(),
                        codigoPostal = c.Int(nullable: false),
                        pais = c.String(),
                        ciudad = c.String(),
                        telefono = c.String(),
                        noCasa = c.Int(nullable: false),
                        Email = c.String(nullable: false, maxLength: 256),
                        Password = c.String(nullable: false, maxLength: 100),
                        ConfirmPassword = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.ApplicationUserSubastas",
                c => new
                    {
                        ApplicationUser_Id = c.String(nullable: false, maxLength: 128),
                        Subasta_subastaID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.ApplicationUser_Id, t.Subasta_subastaID })
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUser_Id, cascadeDelete: true)
                .ForeignKey("dbo.Subastas", t => t.Subasta_subastaID, cascadeDelete: true)
                .Index(t => t.ApplicationUser_Id)
                .Index(t => t.Subasta_subastaID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.ApplicationUserSubastas", "Subasta_subastaID", "dbo.Subastas");
            DropForeignKey("dbo.ApplicationUserSubastas", "ApplicationUser_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Articuloes", "userID", "dbo.AspNetUsers");
            DropForeignKey("dbo.Subastas", "articuloID", "dbo.Articuloes");
            DropIndex("dbo.ApplicationUserSubastas", new[] { "Subasta_subastaID" });
            DropIndex("dbo.ApplicationUserSubastas", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Subastas", new[] { "articuloID" });
            DropIndex("dbo.Articuloes", new[] { "userID" });
            DropTable("dbo.ApplicationUserSubastas");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Subastas");
            DropTable("dbo.Articuloes");
        }
    }
}
