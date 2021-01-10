namespace CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.MovilDatas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false, maxLength: 60),
                        TipoDocumento = c.String(nullable: false),
                        NumDocumento = c.Int(nullable: false),
                        TipoVehiculo = c.String(nullable: false),
                        PlacaVehiculo = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.MovilDatas");
        }
    }
}
