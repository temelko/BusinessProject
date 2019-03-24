namespace Model.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class BusinessProjectDataBase : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DepartmentId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        BaseSalary = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.DepartmentId);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        EmployeeId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Year = c.Int(nullable: false),
                        Status = c.Int(nullable: false),
                        Internship = c.Int(nullable: false),
                        Salary = c.Double(),
                        Dep_DepartmentId = c.Int(),
                    })
                .PrimaryKey(t => t.EmployeeId)
                .ForeignKey("dbo.Departments", t => t.Dep_DepartmentId)
                .Index(t => t.Dep_DepartmentId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "Dep_DepartmentId", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "Dep_DepartmentId" });
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
