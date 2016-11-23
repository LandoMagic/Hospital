using System.Data.Entity.Migrations;

namespace HospitalRepository.Migrations
{
    public partial class ob : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Appointments",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Reason = c.String(),
                        Description = c.String(),
                        DateAdded = c.DateTime(),
                        CreatedBy = c.String(),
                        ApplicationUserId = c.String(),
                        Date = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.BodyOuts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        MotherName = c.String(),
                        FatherName = c.String(),
                        PlaceOfBirth = c.String(),
                        Gender = c.String(),
                        ImageUrl = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ChildBirths",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NameOfChild = c.String(),
                        DateOfBirth = c.DateTime(nullable: false),
                        PlaceOfBirth = c.String(),
                        Gender = c.String(),
                        MotherName = c.String(),
                        FatherName = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.DrugInventories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DrugGenericName = c.String(),
                        DrugBrandName = c.String(),
                        Strength = c.String(),
                        DosageForm = c.String(),
                        ExpiryDate = c.DateTime(nullable: false),
                        BatchNumber = c.Int(nullable: false),
                        Stock = c.String(),
                        DateReceived = c.DateTime(nullable: false),
                        StockQuantity = c.Int(nullable: false),
                        MainCategory = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Groups",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ApplicationRoleGroups",
                c => new
                    {
                        RoleId = c.String(nullable: false, maxLength: 128),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.RoleId, t.GroupId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .Index(t => t.RoleId)
                .Index(t => t.GroupId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false),
                        Description = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Prescriptions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DoctorId = c.Int(nullable: false),
                        PatientId = c.String(),
                        PrescriptionDate = c.DateTime(nullable: false),
                        Drug = c.String(),
                        Details = c.String(),
                        Refills = c.Int(nullable: false),
                        NumberOfTablets = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        UserName = c.String(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        FirstName = c.String(),
                        LastName = c.String(),
                        Email = c.String(),
                        Phone = c.String(),
                        BloodGroup = c.String(),
                        Addresss = c.String(),
                        DateAddded = c.DateTime(),
                        ModifiedBy = c.String(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                        User_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.User_Id, cascadeDelete: true)
                .Index(t => t.User_Id);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.LoginProvider, t.ProviderKey })
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
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.ApplicationUserGroups",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        GroupId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.UserId, t.GroupId })
                .ForeignKey("dbo.Groups", t => t.GroupId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.GroupId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ApplicationUserGroups", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationUserGroups", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.AspNetUserClaims", "User_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ApplicationRoleGroups", "GroupId", "dbo.Groups");
            DropForeignKey("dbo.ApplicationRoleGroups", "RoleId", "dbo.AspNetRoles");
            DropIndex("dbo.ApplicationUserGroups", new[] { "GroupId" });
            DropIndex("dbo.ApplicationUserGroups", new[] { "UserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "User_Id" });
            DropIndex("dbo.ApplicationRoleGroups", new[] { "GroupId" });
            DropIndex("dbo.ApplicationRoleGroups", new[] { "RoleId" });
            DropTable("dbo.ApplicationUserGroups");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Prescriptions");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.ApplicationRoleGroups");
            DropTable("dbo.Groups");
            DropTable("dbo.DrugInventories");
            DropTable("dbo.ChildBirths");
            DropTable("dbo.BodyOuts");
            DropTable("dbo.Appointments");
        }
    }
}
