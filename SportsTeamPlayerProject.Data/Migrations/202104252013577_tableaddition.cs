namespace SportsTeamPlayerProject.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class tableaddition : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PlayerAssignment",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        PlayerName = c.String(maxLength: 128),
                        SportName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Player", t => t.PlayerName)
                .ForeignKey("dbo.Sport", t => t.SportName)
                .Index(t => t.PlayerName)
                .Index(t => t.SportName);
            
            CreateTable(
                "dbo.Player",
                c => new
                    {
                        PlayerName = c.String(nullable: false, maxLength: 128),
                        PlayerId = c.Int(nullable: false),
                        TeamName = c.String(maxLength: 128),
                        SportName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.PlayerName)
                .ForeignKey("dbo.Sport", t => t.SportName)
                .ForeignKey("dbo.Team", t => t.TeamName)
                .Index(t => t.TeamName)
                .Index(t => t.SportName);
            
            CreateTable(
                "dbo.Sport",
                c => new
                    {
                        SportName = c.String(nullable: false, maxLength: 128),
                        SportId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SportName);
            
            CreateTable(
                "dbo.TeamAssignment",
                c => new
                    {
                        SportName = c.String(nullable: false, maxLength: 128),
                        TeamName = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.SportName, t.TeamName })
                .ForeignKey("dbo.Sport", t => t.SportName, cascadeDelete: true)
                .ForeignKey("dbo.Team", t => t.TeamName, cascadeDelete: true)
                .Index(t => t.SportName)
                .Index(t => t.TeamName);
            
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        TeamName = c.String(nullable: false, maxLength: 128),
                        TeamId = c.Int(nullable: false),
                        SportName = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.TeamName)
                .ForeignKey("dbo.Sport", t => t.SportName)
                .Index(t => t.SportName);
            
            CreateTable(
                "dbo.IdentityRole",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserRole",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(),
                        IdentityRole_Id = c.String(maxLength: 128),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.IdentityRole", t => t.IdentityRole_Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.IdentityRole_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.ApplicationUser",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.IdentityUserClaim",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
            CreateTable(
                "dbo.IdentityUserLogin",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(),
                        ProviderKey = c.String(),
                        ApplicationUser_Id = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.UserId)
                .ForeignKey("dbo.ApplicationUser", t => t.ApplicationUser_Id)
                .Index(t => t.ApplicationUser_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.IdentityUserRole", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserLogin", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserClaim", "ApplicationUser_Id", "dbo.ApplicationUser");
            DropForeignKey("dbo.IdentityUserRole", "IdentityRole_Id", "dbo.IdentityRole");
            DropForeignKey("dbo.PlayerAssignment", "SportName", "dbo.Sport");
            DropForeignKey("dbo.PlayerAssignment", "PlayerName", "dbo.Player");
            DropForeignKey("dbo.Player", "TeamName", "dbo.Team");
            DropForeignKey("dbo.Player", "SportName", "dbo.Sport");
            DropForeignKey("dbo.TeamAssignment", "TeamName", "dbo.Team");
            DropForeignKey("dbo.Team", "SportName", "dbo.Sport");
            DropForeignKey("dbo.TeamAssignment", "SportName", "dbo.Sport");
            DropIndex("dbo.IdentityUserLogin", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserClaim", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "ApplicationUser_Id" });
            DropIndex("dbo.IdentityUserRole", new[] { "IdentityRole_Id" });
            DropIndex("dbo.Team", new[] { "SportName" });
            DropIndex("dbo.TeamAssignment", new[] { "TeamName" });
            DropIndex("dbo.TeamAssignment", new[] { "SportName" });
            DropIndex("dbo.Player", new[] { "SportName" });
            DropIndex("dbo.Player", new[] { "TeamName" });
            DropIndex("dbo.PlayerAssignment", new[] { "SportName" });
            DropIndex("dbo.PlayerAssignment", new[] { "PlayerName" });
            DropTable("dbo.IdentityUserLogin");
            DropTable("dbo.IdentityUserClaim");
            DropTable("dbo.ApplicationUser");
            DropTable("dbo.IdentityUserRole");
            DropTable("dbo.IdentityRole");
            DropTable("dbo.Team");
            DropTable("dbo.TeamAssignment");
            DropTable("dbo.Sport");
            DropTable("dbo.Player");
            DropTable("dbo.PlayerAssignment");
        }
    }
}
