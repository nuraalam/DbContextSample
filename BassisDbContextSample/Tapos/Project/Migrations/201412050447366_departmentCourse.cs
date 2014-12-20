namespace Project.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class departmentCourse : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DepartmentCourses",
                c => new
                    {
                        DepartmentCourseID = c.Int(nullable: false, identity: true),
                        CourseID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentCourseID);
            
            AddColumn("dbo.Courses", "DepartmentCourse_DepartmentCourseID", c => c.Int());
            CreateIndex("dbo.Courses", "DepartmentCourse_DepartmentCourseID");
            AddForeignKey("dbo.Courses", "DepartmentCourse_DepartmentCourseID", "dbo.DepartmentCourses", "DepartmentCourseID");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Courses", "DepartmentCourse_DepartmentCourseID", "dbo.DepartmentCourses");
            DropIndex("dbo.Courses", new[] { "DepartmentCourse_DepartmentCourseID" });
            DropColumn("dbo.Courses", "DepartmentCourse_DepartmentCourseID");
            DropTable("dbo.DepartmentCourses");
        }
    }
}
