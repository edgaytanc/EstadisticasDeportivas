using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadisticasDeportivas
{
    internal class EstadisticasPartido
    {
        public string IdPartido { get; set; }
        public Equipo EquipoLocal { get; set; }
        public Equipo EquipoVisitante { get; set; }
        public int GolesLocal { get; set; }
        public int GolesVisitante { get; set; }
        public DateTime Fecha { get; set; }
        public string Sede { get; set; }

        
    }
}
