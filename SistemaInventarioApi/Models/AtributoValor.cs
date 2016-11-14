using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SistemaInventarioApi.Models
{
    public class AtributoValor
    {
        public int Id { get; set; }
        public string Valor { get; set; }

        //relacion 1 a m con dispositivo (1)
        public int DispositivoId { get; set; }
        public virtual Dispositivo Dispositivo { get; set; }

        //relacion 1 a m con atributo (1)
        public int AtributoId { get; set; }
        public virtual Atributo Atributo { get; set; }


    }
}