namespace BangazonOrientation.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addNullableFields : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Computers", "PurchaseDate", c => c.DateTime());
            AlterColumn("dbo.Departments", "Budget", c => c.Decimal(precision: 18, scale: 2));
            AlterColumn("dbo.EmployeeDetails", "StartDate", c => c.DateTime());
            AlterColumn("dbo.EmployeeDetails", "DepartmentID", c => c.Int());
            AlterColumn("dbo.EmployeeDetails", "ComputerID", c => c.Int());
            AlterColumn("dbo.EmployeeDetails", "TrainingStartDate", c => c.DateTime());
            AlterColumn("dbo.Employees", "StartDate", c => c.DateTime());
            AlterColumn("dbo.Employees", "DepartmentID", c => c.Int());
            AlterColumn("dbo.TrainingPrograms", "MaxAttendees", c => c.Int());
            AlterColumn("dbo.TrainingPrograms", "StartDate", c => c.DateTime());
            AlterColumn("dbo.TrainingPrograms", "EndDate", c => c.DateTime());
            DropColumn("dbo.Employees", "DepartmentName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Employees", "DepartmentName", c => c.String());
            AlterColumn("dbo.TrainingPrograms", "EndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TrainingPrograms", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.TrainingPrograms", "MaxAttendees", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "DepartmentID", c => c.Int(nullable: false));
            AlterColumn("dbo.Employees", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EmployeeDetails", "TrainingStartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.EmployeeDetails", "ComputerID", c => c.Int(nullable: false));
            AlterColumn("dbo.EmployeeDetails", "DepartmentID", c => c.Int(nullable: false));
            AlterColumn("dbo.EmployeeDetails", "StartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Departments", "Budget", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Computers", "PurchaseDate", c => c.DateTime(nullable: false));
        }
    }
}
