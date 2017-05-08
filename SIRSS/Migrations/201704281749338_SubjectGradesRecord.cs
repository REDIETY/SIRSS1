namespace SIRSS.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SubjectGradesRecord : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ExamResults",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                        LevelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Levels", t => t.LevelId, cascadeDelete: true)
                .Index(t => t.LevelId);
            
            CreateTable(
                "dbo.Levels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.GradeLevels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Title = c.String(nullable: false, maxLength: 100),
                        Acronym = c.String(nullable: false, maxLength: 20),
                        LevelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Levels", t => t.LevelId, cascadeDelete: true)
                .Index(t => t.LevelId);
            
            CreateTable(
                "dbo.Grades",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ExamResultId = c.Int(nullable: false),
                        GradeValue = c.Decimal(precision: 18, scale: 2),
                        IsDeleted = c.Boolean(nullable: false),
                        SubjectGradesRecord_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ExamResults", t => t.ExamResultId, cascadeDelete: true)
                .ForeignKey("dbo.SubjectGradesRecords", t => t.SubjectGradesRecord_Id)
                .Index(t => t.ExamResultId)
                .Index(t => t.SubjectGradesRecord_Id);
            
            CreateTable(
                "dbo.SubjectGradesRecords",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectId = c.Int(nullable: false),
                        ClassExam = c.Decimal(nullable: false, precision: 18, scale: 2),
                        MidExam = c.Decimal(nullable: false, precision: 18, scale: 2),
                        FinalExam = c.Decimal(nullable: false, precision: 18, scale: 2),
                        IsDeleted = c.Boolean(nullable: false),
                        School_Id = c.Int(),
                        Teacher_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Schools", t => t.School_Id)
                .ForeignKey("dbo.Subjects", t => t.SubjectId, cascadeDelete: true)
                .ForeignKey("dbo.Teachers", t => t.Teacher_ID)
                .Index(t => t.SubjectId)
                .Index(t => t.School_Id)
                .Index(t => t.Teacher_ID);
            
            CreateTable(
                "dbo.Schools",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        schoolname = c.String(),
                        SchoolYearFrom = c.Int(nullable: false),
                        SchoolYearTo = c.Int(nullable: false),
                        SemesterId = c.Int(nullable: false),
                        DateOfRegistration = c.DateTime(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                        Student_Id = c.Int(),
                        Teacher_ID = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Semesters", t => t.SemesterId, cascadeDelete: true)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .ForeignKey("dbo.Teachers", t => t.Teacher_ID)
                .Index(t => t.SemesterId)
                .Index(t => t.Student_Id)
                .Index(t => t.Teacher_ID);
            
            CreateTable(
                "dbo.Semesters",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Students",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        MiddleName = c.String(nullable: false, maxLength: 50),
                        LastName = c.String(nullable: false, maxLength: 50),
                        GradeLevelId = c.Int(nullable: false),
                        EmergencyContact = c.String(nullable: false, maxLength: 50),
                        Woreda = c.String(),
                        kebele = c.String(),
                        SubCity = c.String(),
                        Gender = c.Int(nullable: false),
                        StudentStatus = c.Int(nullable: false),
                        IsDeleted = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.GradeLevels", t => t.GradeLevelId, cascadeDelete: true)
                .Index(t => t.GradeLevelId);
            
            CreateTable(
                "dbo.Subjects",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        SubjectCode = c.String(),
                        Name = c.String(nullable: false, maxLength: 100),
                        NumberOfUnits = c.Int(nullable: false),
                        LevelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Levels", t => t.LevelId, cascadeDelete: true)
                .Index(t => t.LevelId);
            
            CreateTable(
                "dbo.Users",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ParentID = c.Int(),
                        HireDate = c.DateTime(),
                        Discriminator = c.String(nullable: false, maxLength: 128),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Student_Id);
            
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
                "dbo.Teachers",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FirstName1 = c.String(nullable: false, maxLength: 50),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        HireDate = c.DateTime(nullable: false),
                        GradeLevel = c.String(),
                        GradeLevelId = c.Int(nullable: false),
                        Student_Id = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Students", t => t.Student_Id)
                .Index(t => t.Student_Id);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
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
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Users", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.SubjectGradesRecords", "Teacher_ID", "dbo.Teachers");
            DropForeignKey("dbo.Teachers", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Schools", "Teacher_ID", "dbo.Teachers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Grades", "SubjectGradesRecord_Id", "dbo.SubjectGradesRecords");
            DropForeignKey("dbo.SubjectGradesRecords", "SubjectId", "dbo.Subjects");
            DropForeignKey("dbo.Subjects", "LevelId", "dbo.Levels");
            DropForeignKey("dbo.SubjectGradesRecords", "School_Id", "dbo.Schools");
            DropForeignKey("dbo.Schools", "Student_Id", "dbo.Students");
            DropForeignKey("dbo.Students", "GradeLevelId", "dbo.GradeLevels");
            DropForeignKey("dbo.Schools", "SemesterId", "dbo.Semesters");
            DropForeignKey("dbo.Grades", "ExamResultId", "dbo.ExamResults");
            DropForeignKey("dbo.GradeLevels", "LevelId", "dbo.Levels");
            DropForeignKey("dbo.ExamResults", "LevelId", "dbo.Levels");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Teachers", new[] { "Student_Id" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Users", new[] { "Student_Id" });
            DropIndex("dbo.Subjects", new[] { "LevelId" });
            DropIndex("dbo.Students", new[] { "GradeLevelId" });
            DropIndex("dbo.Schools", new[] { "Teacher_ID" });
            DropIndex("dbo.Schools", new[] { "Student_Id" });
            DropIndex("dbo.Schools", new[] { "SemesterId" });
            DropIndex("dbo.SubjectGradesRecords", new[] { "Teacher_ID" });
            DropIndex("dbo.SubjectGradesRecords", new[] { "School_Id" });
            DropIndex("dbo.SubjectGradesRecords", new[] { "SubjectId" });
            DropIndex("dbo.Grades", new[] { "SubjectGradesRecord_Id" });
            DropIndex("dbo.Grades", new[] { "ExamResultId" });
            DropIndex("dbo.GradeLevels", new[] { "LevelId" });
            DropIndex("dbo.ExamResults", new[] { "LevelId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Teachers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Users");
            DropTable("dbo.Subjects");
            DropTable("dbo.Students");
            DropTable("dbo.Semesters");
            DropTable("dbo.Schools");
            DropTable("dbo.SubjectGradesRecords");
            DropTable("dbo.Grades");
            DropTable("dbo.GradeLevels");
            DropTable("dbo.Levels");
            DropTable("dbo.ExamResults");
        }
    }
}
