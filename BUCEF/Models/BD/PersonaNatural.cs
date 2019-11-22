using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BUCEF.Models.BD
{
    public class PersonaNatural
    {
        public int Id {get; set;}
        public string Nombres { get; set; }
        public string Apellidos { get; set; }
        public Persona Persona { get; set; }

        public ICollection<Localizacion> Localizacion { get; set; }
    }
}
