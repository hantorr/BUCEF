using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BUCEF.Models.BD
{
    public class Persona
    {
        public int Id { get; set; }
        public string NumeroDocumento { get; set; }
        public TipoDocumento TipoDocuemto { get; set; }
        public DateTime FechaCreacion { get; set; }

    }

   
}
