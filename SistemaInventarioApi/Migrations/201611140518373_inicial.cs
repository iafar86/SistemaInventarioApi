namespace SistemaInventarioApi.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Atributoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.AtributoValors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Valor = c.String(),
                        DispositivoId = c.Int(nullable: false),
                        AtributoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Atributoes", t => t.AtributoId, cascadeDelete: true)
                .ForeignKey("dbo.Dispositivoes", t => t.DispositivoId, cascadeDelete: true)
                .Index(t => t.DispositivoId)
                .Index(t => t.AtributoId);
            
            CreateTable(
                "dbo.Dispositivoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaAlta = c.DateTime(nullable: false),
                        TipoDispositivoId = c.Int(nullable: false),
                        SectorId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Sectors", t => t.SectorId, cascadeDelete: true)
                .ForeignKey("dbo.TipoDispositivoes", t => t.TipoDispositivoId, cascadeDelete: true)
                .Index(t => t.TipoDispositivoId)
                .Index(t => t.SectorId);
            
            CreateTable(
                "dbo.Historials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Descripcion = c.String(),
                        DispositivoId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dispositivoes", t => t.DispositivoId, cascadeDelete: true)
                .Index(t => t.DispositivoId);
            
            CreateTable(
                "dbo.Sectors",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                        Encargado = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoDispositivoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoUsuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.TipoDispositivoAtributoes",
                c => new
                    {
                        TipoDispositivo_Id = c.Int(nullable: false),
                        Atributo_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.TipoDispositivo_Id, t.Atributo_Id })
                .ForeignKey("dbo.TipoDispositivoes", t => t.TipoDispositivo_Id, cascadeDelete: true)
                .ForeignKey("dbo.Atributoes", t => t.Atributo_Id, cascadeDelete: true)
                .Index(t => t.TipoDispositivo_Id)
                .Index(t => t.Atributo_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dispositivoes", "TipoDispositivoId", "dbo.TipoDispositivoes");
            DropForeignKey("dbo.TipoDispositivoAtributoes", "Atributo_Id", "dbo.Atributoes");
            DropForeignKey("dbo.TipoDispositivoAtributoes", "TipoDispositivo_Id", "dbo.TipoDispositivoes");
            DropForeignKey("dbo.Dispositivoes", "SectorId", "dbo.Sectors");
            DropForeignKey("dbo.Historials", "DispositivoId", "dbo.Dispositivoes");
            DropForeignKey("dbo.AtributoValors", "DispositivoId", "dbo.Dispositivoes");
            DropForeignKey("dbo.AtributoValors", "AtributoId", "dbo.Atributoes");
            DropIndex("dbo.TipoDispositivoAtributoes", new[] { "Atributo_Id" });
            DropIndex("dbo.TipoDispositivoAtributoes", new[] { "TipoDispositivo_Id" });
            DropIndex("dbo.Historials", new[] { "DispositivoId" });
            DropIndex("dbo.Dispositivoes", new[] { "SectorId" });
            DropIndex("dbo.Dispositivoes", new[] { "TipoDispositivoId" });
            DropIndex("dbo.AtributoValors", new[] { "AtributoId" });
            DropIndex("dbo.AtributoValors", new[] { "DispositivoId" });
            DropTable("dbo.TipoDispositivoAtributoes");
            DropTable("dbo.TipoUsuarios");
            DropTable("dbo.TipoDispositivoes");
            DropTable("dbo.Sectors");
            DropTable("dbo.Historials");
            DropTable("dbo.Dispositivoes");
            DropTable("dbo.AtributoValors");
            DropTable("dbo.Atributoes");
        }
    }
}
