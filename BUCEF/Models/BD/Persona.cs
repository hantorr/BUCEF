using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace BUCEF.Models.BD
{
    public class Persona
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public string NumeroDocumento { get; set; }
        public TipoDocumento TipoDocuemto { get; set; }
        public DateTime FechaCreacion { get; set; }

    }

   
}
