using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaInventarioApi.Models
{
    public class Sector
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Encargado { get; set; }

        //relacion 1 a m con Dispositivo (m)
        public virtual ICollection<Dispositivo> Dispositivos { get; set; }


    }
}