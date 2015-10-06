namespace listarproy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class nameylista : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.listas", "list", c => c.Int(nullable: false));
            AddColumn("dbo.ListUsers", "Name", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.ListUsers", "Name");
            DropColumn("dbo.listas", "list");
        }
    }
}
