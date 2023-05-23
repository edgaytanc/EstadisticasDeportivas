using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace EstadisticasDeportivas
{
    public class ListaEnlazadaJugadores
    {
        private NodoJugador _cabeza;

        public ListaEnlazadaJugadores()
        {
            _cabeza = null;
        }

        public void AgregarJugador(Jugador jugador)
        {
            NodoJugador nuevoNodo = new NodoJugador(jugador);

            if (_cabeza == null)
            {
                _cabeza = nuevoNodo;
            }
            else
            {
                NodoJugador actual = _cabeza;
                while (actual.Siguiente != null)
                {
                    actual = actual.Siguiente;
                }
                actual.Siguiente = nuevoNodo;
            }
        }

        public Jugador BuscarJugador(string nombreCompleto)
        {
            NodoJugador actual = _cabeza;
            while (actual != null)
            {
                if (actual.Jugador.FullName == nombreCompleto)
                {
                    return actual.Jugador;
                }
                actual = actual.Siguiente;
            }

            return null;
        }

        public void ImprimirJugadores()
        {
            NodoJugador nodoActual = _cabeza;

            while (nodoActual != null)
            {
                Jugador jugador = nodoActual.Jugador;
                StringBuilder jugadorInfo = new StringBuilder();

                jugadorInfo.AppendLine($"Nombre: {jugador.FullName}");
                jugadorInfo.AppendLine($"Edad: {jugador.Age}");
                jugadorInfo.AppendLine($"Fecha de nacimiento: {jugador.Birthday.ToString("yyyy-MM-dd")}");
                jugadorInfo.AppendLine($"Liga: {jugador.League}");
                jugadorInfo.AppendLine($"Temporada: {jugador.Season}");
                jugadorInfo.AppendLine($"Posición: {jugador.Position}");
                jugadorInfo.AppendLine($"Club: {jugador.Club}");
                jugadorInfo.AppendLine($"Minutos Jugados en general: {jugador.MinutesPlayedOverall}");
                jugadorInfo.AppendLine($"Minutos Jugados en casa: {jugador.MinutesPlayedHome}");
                jugadorInfo.AppendLine($"Minutos Jugados: {jugador.MinutesPlayedAway}");
                jugadorInfo.AppendLine($"Nacionalidad: {jugador.Nationality}");
                jugadorInfo.AppendLine($"Apariciones en general: {jugador.AppearancesOverall}");
                jugadorInfo.AppendLine($"Apariciones en Local: {jugador.AppearancesHome}");
                jugadorInfo.AppendLine($"Apariciones fuera: {jugador.AppearancesAway}");
                jugadorInfo.AppendLine($"Goles en general: {jugador.GoalsOverall}");
                jugadorInfo.AppendLine($"Goles en casa: {jugador.GoalsHome}");
                jugadorInfo.AppendLine($"Goles fuera: {jugador.GoalsAway}");
                jugadorInfo.AppendLine($"Goles de penalti: {jugador.PenaltyGoals}");
                jugadorInfo.AppendLine($"Faltas de penalti: {jugador.PenaltyMisses}");
                jugadorInfo.AppendLine($"Hojas limpias en General: {jugador.CleanSheetsOverall}");
                jugadorInfo.AppendLine($"Hojas limpias en Casa: {jugador.CleanSheetsHome}");
                jugadorInfo.AppendLine($"Hojas limpias Fuera: {jugador.CleanSheetsAway}");
                jugadorInfo.AppendLine($"Concedido General: {jugador.ConcededOverall}");
                jugadorInfo.AppendLine($"Concedido en Casa: {jugador.ConcededHome}");

                jugadorInfo.AppendLine($"Concedido lejos: {jugador.ConcededAway}");
                jugadorInfo.AppendLine($"Goles involucrados en 90 min: {jugador.GoalsInvolvedPer90Overall}");



                // ... (Agregar todas las propiedades que desees mostrar)

                jugadorInfo.AppendLine(); // Agregar una línea en blanco entre jugadores
                Console.WriteLine(jugadorInfo.ToString());

                nodoActual = nodoActual.Siguiente;
            }
        }

        public List<Jugador> ObtenerTodos()
        {
            List<Jugador> listaJugadores = new List<Jugador>();
            NodoJugador actual = _cabeza;

            while (actual != null)
            {
                listaJugadores.Add(actual.Jugador);
                actual = actual.Siguiente;
            }

            return listaJugadores;
        }

        public List<string> JugadoresPorEquipo(string equipo)
        {
            List<string> jugadoresEquipo = new List<string>();
            NodoJugador actual = _cabeza;

            while (actual != null)
            {
                if (actual.Jugador.Club == equipo)
                {
                    jugadoresEquipo.Add(actual.Jugador.FullName);
                }
                actual = actual.Siguiente;
            }

            return jugadoresEquipo;
        }

        public void ActualizarJugador(string nombreCompleto, Jugador nuevoJugador)
        {
            NodoJugador actual = _cabeza;

            while (actual != null)
            {
                if (actual.Jugador.FullName == nombreCompleto)
                {
                    actual.Jugador = nuevoJugador;
                    break;
                }
                actual = actual.Siguiente;
            }
        }

        public void EliminarJugador(string nombreCompleto)
        {
            NodoJugador actual = _cabeza;
            NodoJugador anterior = null;

            while (actual != null)
            {
                if (actual.Jugador.FullName == nombreCompleto)
                {
                    // Si el nodo a eliminar es el primero (cabeza)
                    if (anterior == null)
                    {
                        _cabeza = actual.Siguiente;
                    }
                    // Si el nodo a eliminar está en medio o al final
                    else
                    {
                        anterior.Siguiente = actual.Siguiente;
                    }
                    break;
                }
                anterior = actual;
                actual = actual.Siguiente;
            }
        }

        public void GuardarListaEnArchivo(string archivoRuta)
        {
            StringBuilder csv = new StringBuilder();

            // Encabezados del CSV
            string encabezado = "\"full_name\",\"age\",\"birthday\",\"league\",\"season\",\"position\",\"Club\",\"minutes_played_overall\",\"minutes_played_home\",\"minutes_played_away\",\"nationality\",\"appearances_overall\",\"appearances_home\",\"appearances_away\",\"goals_overall\",\"goals_home\",\"goals_away\",\"assists_overall\",\"assists_home\",\"assists_away\",\"penalty_goals\",\"penalty_misses\",\"clean_sheets_overall\",\"clean_sheets_home\",\"clean_sheets_away\",\"conceded_overall\",\"conceded_home\",\"conceded_away\",\"yellow_cards_overall\",\"red_cards_overall\",\"goals_involved_per_90_overall\",\"assists_per_90_overall\",\"goals_per_90_overall\",\"goals_per_90_home\",\"goals_per_90_away\",\"min_per_goal_overall\",\"conceded_per_90_overall\",\"min_per_conceded_overall\",\"min_per_match\",\"min_per_card_overall\",\"min_per_assist_overall\",\"cards_per_90_overall\",\"rank_in_league_top_attackers\",\"rank_in_league_top_midfielders\",\"rank_in_league_top_defenders\",\"rank_in_club_top_scorer\"";
            csv.AppendLine(encabezado);

            // Obtener todos los jugadores de la lista
            List<Jugador> jugadores = this.ObtenerTodos();

            // Iterar a través de cada jugador
            foreach (var jugador in jugadores)
            {
                // Convertir los valores de las propiedades del jugador a una línea CSV
                var line = string.Join(",", typeof(Jugador).GetProperties().Select(prop => {
                    var value = prop.GetValue(jugador);
                    if (value is string)
                    {
                        // Añadir comillas dobles si el valor es de tipo string
                        return $"\"{value}\"";
                    }
                    else if (value is DateTime)
                    {
                        // Formatear a "yyyy/MM/dd" y añadir comillas dobles si el valor es de tipo DateTime
                        return $"\"{((DateTime)value).ToString("yyyy/MM/dd")}\"";
                    }
                    else
                    {
                        // No añadir comillas dobles si el valor es de otro tipo
                        return $"{value}";
                    }
                }));
                csv.AppendLine(line);
            }

            // Guardar la cadena CSV en el archivo
            File.WriteAllText(archivoRuta, csv.ToString());
        }





        // Implementar otros métodos según sea necesario, como EliminarJugador, ActualizarJugador, etc.
    }
}
