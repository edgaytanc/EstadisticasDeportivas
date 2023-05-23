using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadisticasDeportivas
{
    internal class TablaHash
    {
        private int capacidad;
        private LinkedList<EstadisticasPartido>[] tabla;

        public TablaHash(int capacidad)
        {
            this.capacidad = capacidad;
            tabla = new LinkedList<EstadisticasPartido>[capacidad];
            for (int i = 0; i < capacidad; i++)
            {
                tabla[i] = new LinkedList<EstadisticasPartido>();
            }
        }

        private int Hash(string clave)
        {
            int hash = 0;
            foreach (char c in clave)
            {
                hash = (hash * 31) + c;
            }
            return Math.Abs(hash % capacidad);
        }

        public void Insertar(EstadisticasPartido partido)
        {
            int indice = Hash(partido.IdPartido);
            tabla[indice].AddLast(partido);
        }

        public EstadisticasPartido Buscar(string idPartido)
        {
            int indice = Hash(idPartido);
            foreach (EstadisticasPartido partido in tabla[indice])
            {
                if (partido.IdPartido == idPartido)
                {
                    return partido;
                }
            }
            return null;
        }

        public bool Eliminar(string idPartido)
        {
            int indice = Hash(idPartido);
            EstadisticasPartido partidoEliminar = null;

            foreach (EstadisticasPartido partido in tabla[indice])
            {
                if (partido.IdPartido == idPartido)
                {
                    partidoEliminar = partido;
                    break;
                }
            }

            if (partidoEliminar != null)
            {
                tabla[indice].Remove(partidoEliminar);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
