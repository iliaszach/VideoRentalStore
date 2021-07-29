namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddGenresTable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Genres", "Kind", c => c.String(nullable: false, maxLength: 120));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Genres", "Kind", c => c.String());
        }
    }
}
