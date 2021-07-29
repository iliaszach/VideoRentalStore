namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeNameProperty : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Movies", "ReleaseDate", c => c.DateTime());
            DropColumn("dbo.Movies", "RealiseDate");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Movies", "RealiseDate", c => c.DateTime());
            DropColumn("dbo.Movies", "ReleaseDate");
        }
    }
}
