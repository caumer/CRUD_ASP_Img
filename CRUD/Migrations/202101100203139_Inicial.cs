namespace CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.FilePaths", "PersonID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.FilePaths", "PersonID", c => c.Int(nullable: false));
        }
    }
}
