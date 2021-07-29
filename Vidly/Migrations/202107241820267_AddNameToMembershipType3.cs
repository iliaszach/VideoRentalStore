namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameToMembershipType3 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE MembershipTypes SET Name='Weekly' WHERE Id=2");
            Sql("UPDATE MembershipTypes SET Name='Montly' WHERE Id=3");
            Sql("UPDATE MembershipTypes SET Name='Yearly' WHERE Id=4");
        }
        
        public override void Down()
        {
        }
    }
}
