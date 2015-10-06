namespace listarproy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changes : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Scheduleds",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Until = c.DateTime(nullable: false),
                        list = c.Int(nullable: false),
                        Finished = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Scheduleds");
        }
    }
}
