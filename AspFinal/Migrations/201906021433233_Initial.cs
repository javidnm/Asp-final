namespace AspFinal.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AcademicBackgrounds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Qualification = c.String(),
                        Degree = c.String(),
                        UniversityName = c.String(),
                        YearOfObtention = c.String(),
                        Details = c.String(),
                        MediaUrl = c.String(),
                        DeletedDate = c.DateTime(),
                        CreatedDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Admins",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Password = c.String(),
                        DeletedDate = c.DateTime(),
                        CreatedDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Bios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Description = c.String(),
                        SkillLevel = c.String(),
                        SkillDescription = c.String(),
                        IsBar = c.Boolean(nullable: false),
                        IsTag = c.Boolean(nullable: false),
                        CategoriesId = c.Int(nullable: false),
                        SkillsId = c.Int(nullable: false),
                        DeletedDate = c.DateTime(),
                        CreatedDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategoriesId, cascadeDelete: true)
                .ForeignKey("dbo.Skills", t => t.SkillsId, cascadeDelete: true)
                .Index(t => t.CategoriesId)
                .Index(t => t.SkillsId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DeletedDate = c.DateTime(),
                        CreatedDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Skills",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DeletedDate = c.DateTime(),
                        CreatedDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Contacts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Email = c.String(),
                        Content = c.String(),
                        Subject = c.String(),
                        Answer = c.String(),
                        Name = c.String(),
                        IsReady = c.Boolean(nullable: false),
                        DeletedDate = c.DateTime(),
                        CreatedDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ErrorHistories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        AreaName = c.String(),
                        ControllerName = c.String(),
                        ActionName = c.String(),
                        ErrorCode = c.Int(),
                        ErrorMessage = c.String(),
                        DeletedDate = c.DateTime(),
                        CreatedDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.PersonDetails",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Age = c.Int(nullable: false),
                        Location = c.String(),
                        Experience = c.String(),
                        Degree = c.String(),
                        CareerLevel = c.String(),
                        Phone = c.String(),
                        Fax = c.String(),
                        Email = c.String(),
                        Website = c.String(),
                        MediaUrl = c.String(),
                        DeletedDate = c.DateTime(),
                        CreatedDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.ProfessionalExperiences",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Duration = c.String(),
                        Title = c.String(),
                        CompanyName = c.String(),
                        Location = c.String(),
                        Details = c.String(),
                        DeletedDate = c.DateTime(),
                        CreatedDate = c.DateTime(),
                        UpdateDate = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Bios", "SkillsId", "dbo.Skills");
            DropForeignKey("dbo.Bios", "CategoriesId", "dbo.Categories");
            DropIndex("dbo.Bios", new[] { "SkillsId" });
            DropIndex("dbo.Bios", new[] { "CategoriesId" });
            DropTable("dbo.ProfessionalExperiences");
            DropTable("dbo.PersonDetails");
            DropTable("dbo.ErrorHistories");
            DropTable("dbo.Contacts");
            DropTable("dbo.Skills");
            DropTable("dbo.Categories");
            DropTable("dbo.Bios");
            DropTable("dbo.Admins");
            DropTable("dbo.AcademicBackgrounds");
        }
    }
}
