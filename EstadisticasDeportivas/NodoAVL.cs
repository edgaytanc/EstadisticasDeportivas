using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadisticasDeportivas
{
    internal class NodoAVL
    {
        public Equipo Equipo { get; set; }
        public NodoAVL Izquierda { get; set; }
        public NodoAVL Derecha { get; set; }
        public int Altura { get; set; }

        public NodoAVL(Equipo equipo)
        {
            Equipo = equipo;
            Izquierda = null;
            Derecha = null;
            Altura = 1;
        }
    }
}
