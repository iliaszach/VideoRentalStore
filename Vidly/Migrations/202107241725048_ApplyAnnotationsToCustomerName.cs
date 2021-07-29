namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ApplyAnnotationsToCustomerName : DbMigration
    {
        public override void Up()
        {
            DropIndex("dbo.Customers", new[] { "membershipTypeId" });
            AddColumn("dbo.MembershipTypes", "SignUpFee", c => c.Short(nullable: false));
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false, maxLength: 255));
            CreateIndex("dbo.Customers", "MembershipTypeId");
            DropColumn("dbo.MembershipTypes", "SignUpFree");
        }
        
        public override void Down()
        {
            AddColumn("dbo.MembershipTypes", "SignUpFree", c => c.Short(nullable: false));
            DropIndex("dbo.Customers", new[] { "MembershipTypeId" });
            AlterColumn("dbo.Customers", "Name", c => c.String());
            DropColumn("dbo.MembershipTypes", "SignUpFee");
            CreateIndex("dbo.Customers", "membershipTypeId");
        }
    }
}
