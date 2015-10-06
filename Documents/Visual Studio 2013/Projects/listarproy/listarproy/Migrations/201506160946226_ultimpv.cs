namespace listarproy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ultimpv : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.listas", "Cel", c => c.Long());
            AddColumn("dbo.listas", "Email", c => c.String());
            AddColumn("dbo.listas", "Otros", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.listas", "Otros");
            DropColumn("dbo.listas", "Email");
            DropColumn("dbo.listas", "Cel");
        }
    }
}
