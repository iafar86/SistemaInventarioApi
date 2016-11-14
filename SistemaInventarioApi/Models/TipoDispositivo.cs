using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaInventarioApi.Models
{
    public class TipoDispositivo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        
        //relacion 1 a m con Dispositivo (m)
        public virtual ICollection<Dispositivo> Dispositivos { get; set; }

        //relacion 1 a m con atributo
        public virtual ICollection<Atributo> Atributos { get; set; }

    }
}