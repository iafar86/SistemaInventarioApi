using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaInventarioApi.Models
{
    public class Atributo
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        //relacion 1 a m con TipoDispositivo (m)
        public virtual ICollection<TipoDispositivo> TiposDispositivo { get; set; }

        //relacion 1 a m con atributoValor (m)
        public virtual ICollection<AtributoValor> AtributosValor { get; set; }



    }
}