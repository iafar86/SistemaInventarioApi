using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaInventarioApi.Models
{
    public class Dispositivo
    {
        public int Id { get; set; }
        public DateTime FechaAlta { get; set; }

        //relacion 1 a m con TipoDispositivo (1)
        public int TipoDispositivoId { get; set; }
        public virtual TipoDispositivo TipoDispositivo { get; set; }

        //relacion 1 a m con Historial (m)
        public virtual ICollection<Historial> Historiales { get; set; }

        //relacion 1 a m con Sector (1)
        public int SectorId { get; set; }
        public virtual Sector Sector { get; set; }

        //relacion 1 a m con atributoValor (m)
        public virtual ICollection<AtributoValor> AtributosValor { get; set; }



    }
}