namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class PopulateBirthdateToCustomersTable1 : DbMigration
    {
        public override void Up()
        {
            Sql("UPDATE Customers SET Birthdate =CAST('1990-7-20' AS DATETIME) WHERE Id = 2");
            Sql("UPDATE Customers SET Birthdate =CAST('1989-6-15' AS DATETIME) WHERE Id = 3");
            Sql("UPDATE Customers SET Birthdate =CAST('1995-3-22' AS DATETIME) WHERE Id = 4");

        }

        public override void Down()
        {
        }
    }
}
