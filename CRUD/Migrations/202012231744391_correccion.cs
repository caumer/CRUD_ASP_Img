namespace CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class correccion : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MovilDatas", "Nombre", c => c.String(nullable: false, maxLength: 40));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MovilDatas", "Nombre", c => c.String(nullable: false, maxLength: 60));
        }
    }
}
