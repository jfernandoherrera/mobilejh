namespace listarproy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class strin : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.ListUsers", "IdUser", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.ListUsers", "IdUser", c => c.Int(nullable: false));
        }
    }
}
