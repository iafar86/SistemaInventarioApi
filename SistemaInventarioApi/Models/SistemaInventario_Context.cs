using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;



namespace SistemaInventarioApi.Models
{
    public class SistemaInventario_Context :  DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public SistemaInventario_Context() : base("name=SistemaInventario_Context")
        {
        }

        public System.Data.Entity.DbSet<SistemaInventarioApi.Models.Atributo> Atributoes { get; set; }

        public System.Data.Entity.DbSet<SistemaInventarioApi.Models.AtributoValor> AtributoValors { get; set; }

        public System.Data.Entity.DbSet<SistemaInventarioApi.Models.Dispositivo> Dispositivoes { get; set; }

        public System.Data.Entity.DbSet<SistemaInventarioApi.Models.Sector> Sectors { get; set; }

        public System.Data.Entity.DbSet<SistemaInventarioApi.Models.TipoDispositivo> TipoDispositivoes { get; set; }

        public System.Data.Entity.DbSet<SistemaInventarioApi.Models.Historial> Historials { get; set; }

        public System.Data.Entity.DbSet<SistemaInventarioApi.Models.TipoUsuario> TipoUsuarios { get; set; }
    
    }
}
