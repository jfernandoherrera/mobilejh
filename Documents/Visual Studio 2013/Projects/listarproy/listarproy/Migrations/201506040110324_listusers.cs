namespace listarproy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class listusers : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ListUsers",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        IdUser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ListUsers");
        }
    }
}
