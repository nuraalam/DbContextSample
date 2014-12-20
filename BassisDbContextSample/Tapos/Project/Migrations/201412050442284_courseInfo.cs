namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class courseInfo : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Courses",
                c => new
                    {
                        CourseID = c.Int(nullable: false, identity: true),
                        Code = c.String(),
                        Name = c.String(),
                        Credit = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.CourseID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Courses");
        }
    }
}
