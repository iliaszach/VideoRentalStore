namespace Vidly.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class MakeReleaseDateNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Movies", "RealiseDate", c => c.DateTime());
            AlterColumn("dbo.Movies", "NumberInStock", c => c.Byte(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Movies", "NumberInStock", c => c.Int(nullable: false));
            AlterColumn("dbo.Movies", "RealiseDate", c => c.DateTime(nullable: false));
        }
    }
}
