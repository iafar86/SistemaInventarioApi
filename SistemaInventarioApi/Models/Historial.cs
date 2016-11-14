using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaInventarioApi.Models
{
    public class Historial
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }
        public string Descripcion { get; set; }

        //relacion 1 a m con Dispositivo (1)
        public int DispositivoId { get; set; }
        public virtual Dispositivo Dispositivo { get; set; }



    }
}