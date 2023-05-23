using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadisticasDeportivas
{
    public class ArbolAVL
    {
        private NodoAVL raiz;

        public ArbolAVL()
        {
            raiz = null;
        }

        public void Insertar(Equipo equipo)
        {
            raiz = Insertar(raiz, equipo);
        }

        private NodoAVL Insertar(NodoAVL nodo, Equipo equipo)
        {
            if (nodo == null)
            {
                return new NodoAVL(equipo);
            }
            int comparacion = string.Compare(equipo.teamName, nodo.Equipo.teamName);

            if (comparacion < 0)
            {
                nodo.Izquierda = Insertar(nodo.Izquierda, equipo);
            }
            else if (comparacion > 0)
            {
                nodo.Derecha = Insertar(nodo.Derecha, equipo);
            }
            else
            {
                // No permitir equipos duplicados
                return nodo;
            }
            nodo.Altura = 1 + Math.Max(Altura(nodo.Izquierda), Altura(nodo.Derecha));

            int balance = Balance(nodo);

            if (balance > 1)
            {
                if (string.Compare(equipo.teamName, nodo.Izquierda.Equipo.teamName) < 0)
                {
                    return RotarDerecha(nodo);
                }
                else
                {
                    nodo.Izquierda = RotarIzquierda(nodo.Izquierda);
                    return RotarDerecha(nodo);
                }
            }
            if (balance < -1)
            {
                if (string.Compare(equipo.teamName, nodo.Derecha.Equipo.teamName) > 0)
                {
                    return RotarIzquierda(nodo);
                }
                else
                {
                    nodo.Derecha = RotarDerecha(nodo.Derecha);
                    return RotarIzquierda(nodo);
                }
            }

            return nodo;
        }

        public Equipo Buscar(string nombreEquipo)
        {
            NodoAVL nodo = Buscar(raiz, nombreEquipo);
            return nodo == null ? null : nodo.Equipo;
        }

        private NodoAVL Buscar(NodoAVL nodo, string nombreEquipo)
        {
            if (nodo == null || nodo.Equipo.commonName == nombreEquipo)
            {
                return nodo;
            }

            if (string.Compare(nombreEquipo, nodo.Equipo.commonName) < 0)
            {
                return Buscar(nodo.Izquierda, nombreEquipo);
            }
            else
            {
                return Buscar(nodo.Derecha, nombreEquipo);
            }
        }

        public void Eliminar(string nombreEquipo)
        {
            raiz = Eliminar(raiz, nombreEquipo);
        }

        private NodoAVL Eliminar(NodoAVL nodo, string nombreEquipo)
        {
            if (nodo == null)
            {
                return nodo;
            }

            int comparacion = string.Compare(nombreEquipo, nodo.Equipo.teamName);

            if (comparacion < 0)
            {
                nodo.Izquierda = Eliminar(nodo.Izquierda, nombreEquipo);
            }
            else if (comparacion > 0)
            {
                nodo.Derecha = Eliminar(nodo.Derecha, nombreEquipo);
            }
            else
            {
                // Si el nodo tiene uno o ningún hijo
                if (nodo.Izquierda == null)
                {
                    NodoAVL temp = nodo.Derecha;
                    nodo = null;
                    return temp;
                }
                else if (nodo.Derecha == null)
                {
                    NodoAVL temp = nodo.Izquierda;
                    nodo = null;
                    return temp;
                }

                // Si el nodo tiene dos hijos: obtener el nodo en orden del sucesor (el más pequeño en la subárbol derecha)
                NodoAVL tempMinValor = MinimoValor(nodo.Derecha);

                // Copiar el contenido del sucesor del nodo a este nodo
                nodo.Equipo = tempMinValor.Equipo;

                // Eliminar el sucesor en orden
                nodo.Derecha = Eliminar(nodo.Derecha, tempMinValor.Equipo.teamName);
            }

            // Si el árbol solo tiene un nodo, simplemente lo devolvemos
            if (nodo == null)
            {
                return nodo;
            }

            // Actualizar altura del nodo actual
            nodo.Altura = 1 + Math.Max(Altura(nodo.Izquierda), Altura(nodo.Derecha));

            // Verificar balance
            int balance = Balance(nodo);

            // Si el nodo está desequilibrado, entonces hay 4 casos

            // Caso Izquierda Izquierda
            if (balance > 1 && Balance(nodo.Izquierda) >= 0)
            {
                return RotarDerecha(nodo);
            }

            // Caso Derecha Derecha
            if (balance < -1 && Balance(nodo.Derecha) <= 0)
            {
                return RotarIzquierda(nodo);
            }

            // Caso Izquierda Derecha
            if (balance > 1 && Balance(nodo.Izquierda) < 0)
            {
                nodo.Izquierda = RotarIzquierda(nodo.Izquierda);
                return RotarDerecha(nodo);
            }

            // Caso Derecha Izquierda
            if (balance < -1 && Balance(nodo.Derecha) > 0)
            {
                nodo.Derecha = RotarDerecha(nodo.Derecha);
                return RotarIzquierda(nodo);
            }

            return nodo;
        }




        private NodoAVL MinimoValor(NodoAVL nodo)
        {
            NodoAVL actual = nodo;

            while (actual.Izquierda != null)
            {
                actual = actual.Izquierda;
            }

            return actual;
        }

        private int Altura(NodoAVL nodo)
        {
            return nodo == null ? 0 : nodo.Altura;
        }

        private int Balance(NodoAVL nodo)
        {
            return nodo == null ? 0 : Altura(nodo.Izquierda) - Altura(nodo.Derecha);
        }

        private NodoAVL RotarDerecha(NodoAVL y)
        {
            NodoAVL x = y.Izquierda;
            NodoAVL T2 = x.Derecha;

            x.Derecha = y;
            y.Izquierda = T2;

            y.Altura = 1 + Math.Max(Altura(y.Izquierda), Altura(y.Derecha));
            x.Altura = 1 + Math.Max(Altura(x.Izquierda), Altura(x.Derecha));

            return x;
        }

        private NodoAVL RotarIzquierda(NodoAVL x)
        {
            NodoAVL y = x.Derecha;
            NodoAVL T2 = y.Izquierda;

            y.Izquierda = x;
            x.Derecha = T2;

            x.Altura = 1 + Math.Max(Altura(x.Izquierda), Altura(x.Derecha));
            y.Altura = 1 + Math.Max(Altura(y.Izquierda), Altura(y.Derecha));

            return y;
        }

        // Método para imprimir el árbol en orden
        public void imprimir()
        {
            imprimir(raiz);
        }

        private void imprimir(NodoAVL nodo)
        {
            if (nodo != null)
            {
                imprimir(nodo.Izquierda);
                Console.WriteLine("Dato: " + nodo.Equipo.teamName + ", Altura: " + nodo.Altura);
                imprimir(nodo.Derecha);
            }
        }

        public List<Equipo> ObtenerTodos()
        {
            List<Equipo> equipos = new List<Equipo>();
            ObtenerTodos(raiz, equipos);
            return equipos;
        }

        private void ObtenerTodos(NodoAVL nodo, List<Equipo> equipos)
        {
            if (nodo != null)
            {
                ObtenerTodos(nodo.Izquierda, equipos);
                equipos.Add(nodo.Equipo);
                ObtenerTodos(nodo.Derecha, equipos);
            }
        }

        public void GuardarArbolEnArchivo(string archivoRuta)
        {
            StringBuilder csv = new StringBuilder();

            // Encabezados del CSV
            string encabezado = "\"team_name\",\"common_name\",\"season\",\"country\",\"matches_played\",\"suspended_matches\",\"wins\",\"draws\",\"losses\",\"points_per_game\",\"league_position\",\"goals_scored\",\"goals_conceded\",\"goal_difference\",\"total_goal_count\",\"minutes_per_goal_scored\",\"minutes_per_goal_conceded\",\"clean_sheets\",\"first_team_to_score_count\",\"corners_total\",\"cards_total\",\"average_possession\",\"shots\",\"shots_home\",\"shots_away\",\"shots_on_target\",\"shots_off_target\",\"fouls\",\"fouls_home\",\"fouls_away\",\"goals_scored_half_time\",\"goals_conceded_half_time\",\"goal_difference_half_time\",\"leading_at_half_time\",\"draw_at_half_time\",\"losing_at_half_time\",\"average_total_goals_per_match\",\"goals_scored_per_match\",\"goals_conceded_per_match\",\"total_goals_per_match_half_time\",\"goals_scored_per_match_half_time\",\"goals_conceded_per_match_half_time\",\"win_percentage\",\"home_advantage_percentage\",\"clean_sheet_percentage\",\"draw_at_half_time_percentage\",\"corners_per_match\",\"cards_per_match\"";
            csv.AppendLine(encabezado);

            // Obtener todos los nodos del árbol en inorden
            List<Equipo> equipos = ObtenerTodos();

            // Iterar a través de cada nodo
            foreach (var equipo in equipos)
            {
                // Convertir los valores de las propiedades del equipo a una línea CSV
                var line = string.Join(",", typeof(Equipo).GetProperties().Select(prop => {
                    var value = prop.GetValue(equipo);
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

        private List<Equipo> Inorden(NodoAVL nodo = null, List<Equipo> nodos = null)
        {
            if (nodos == null)
            {
                nodos = new List<Equipo>();
            }

            if (nodo != null)
            {
                Inorden(nodo.Izquierda, nodos);
                nodos.Add(nodo.Equipo);
                Inorden(nodo.Derecha, nodos);
            }

            return nodos;
        }

        public void Actualizar(Equipo actual, Equipo nuevo)
        {
            NodoAVL nodo = Buscar(raiz, actual.teamName);
            if (nodo != null)
            {
                // Asegúrate de que el nuevo equipo tenga la misma llave (teamName) que el equipo actual
                nuevo.teamName = actual.teamName;
                nodo.Equipo = nuevo;
            }
            else
            {
                throw new Exception($"No se pudo encontrar el equipo {actual.teamName} para actualizar.");
            }
        }



    }
}
