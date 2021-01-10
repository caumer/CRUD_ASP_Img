namespace CRUD.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class imgprueba03 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.MovilDatas", newName: "datosBasicos");
            CreateTable(
                "dbo.FilePaths",
                c => new
                    {
                        FilePathId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        FileType = c.Int(nullable: false),
                        PersonID = c.Int(nullable: false),
                        datosBasicos_Id = c.Int(),
                    })
                .PrimaryKey(t => t.FilePathId)
                .ForeignKey("dbo.datosBasicos", t => t.datosBasicos_Id)
                .Index(t => t.datosBasicos_Id);
            
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        datosBasicosId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.datosBasicos", t => t.datosBasicosId, cascadeDelete: true)
                .Index(t => t.datosBasicosId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Files", "datosBasicosId", "dbo.datosBasicos");
            DropForeignKey("dbo.FilePaths", "datosBasicos_Id", "dbo.datosBasicos");
            DropIndex("dbo.Files", new[] { "datosBasicosId" });
            DropIndex("dbo.FilePaths", new[] { "datosBasicos_Id" });
            DropTable("dbo.Files");
            DropTable("dbo.FilePaths");
            RenameTable(name: "dbo.datosBasicos", newName: "MovilDatas");
        }
    }
}
