namespace listarproy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _checked : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.listas", "Checked", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.listas", "Checked");
        }
    }
}
