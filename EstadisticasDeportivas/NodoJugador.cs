using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadisticasDeportivas
{
    internal class NodoJugador
    {
        public Jugador Jugador { get; set; }
        public NodoJugador Siguiente { get; set; }

        public NodoJugador(Jugador jugador)
        {
            Jugador = jugador;
            Siguiente = null;
        }
    }
}
