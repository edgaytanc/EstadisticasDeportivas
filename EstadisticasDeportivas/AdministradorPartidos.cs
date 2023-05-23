using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;

namespace EstadisticasDeportivas
{
    public class AdministradorPartidos
    {
        Hashtable tablaPartidos;
        String path;
        public AdministradorPartidos(String path)
        {
            this.path = path;
            tablaPartidos = LeerPartidos(path);
        }

        public Hashtable getTablaPartido()
        {
            return tablaPartidos;
        }

        public List<Partido> ObtenerTodos()
        {
            List<Partido> partidos = new List<Partido>();
            foreach (DictionaryEntry entry in tablaPartidos)
            {
                partidos.Add((Partido)entry.Value);
            }
            return partidos;
        }

        public Partido buscarPartido()
        {
            return new Partido();
        }

        public void Ingresar(Partido partido)
        {
            // Debes generar un ID para este partido. Asumiré que el próximo ID será el número total de partidos existentes + 1.
            int nuevoId = tablaPartidos.Count + 1;

            // Asigna el Id al partido
            partido.Id = nuevoId;

            // Agrega el partido a la tabla de partidos con el nuevo ID
            tablaPartidos.Add(nuevoId, partido);
        }

        public void Eliminar(Partido partido)
        {
            // Usa el ID del partido que queremos eliminar
            int idPartido = partido.Id;

            // Verifica si el ID existe en la tabla de partidos
            if (tablaPartidos.ContainsKey(idPartido))
            {
                // Si el partido existe, eliminalo
                tablaPartidos.Remove(idPartido);
            }
            else
            {
                throw new KeyNotFoundException($"No se encontró ningún partido con el ID {idPartido}.");
            }
        }

        public void Actualizar(Partido partido)
        {
            // Comprueba si el partido es null
            if (partido == null)
            {
                throw new ArgumentNullException("partido", "El partido no puede ser null.");
            }

            // Comprueba si tablaPartidos es null
            if (tablaPartidos == null)
            {
                throw new NullReferenceException("La tabla de partidos no se ha inicializado.");
            }

            // Usa el ID del partido que queremos actualizar
            int idPartido = partido.Id;

            // Verifica si el ID existe en la tabla de partidos
            if (tablaPartidos.ContainsKey(idPartido))
            {
                // Si el partido existe, actualízalo
                tablaPartidos[idPartido] = partido;
            }
            else
            {
                throw new KeyNotFoundException($"No se encontró ningún partido con el ID {idPartido}.");
            }
        }


        public Partido buscar(int id)
        {
            // Verifica si el ID existe en la tabla de partidos
            if (tablaPartidos.ContainsKey(id))
            {
                // Si el partido existe, devuélvelo
                return (Partido)tablaPartidos[id];
            }
            else
            {
                throw new KeyNotFoundException($"No se encontró ningún partido con el ID {id}.");
            }
        }


        public static Hashtable LeerPartidos(string path)
        {
            var partidosHashTable = new Hashtable();

            var config = new CsvConfiguration(CultureInfo.InvariantCulture)
            {
                // Permitir la coincidencia de mayúsculas y minúsculas
                PrepareHeaderForMatch = args => args.Header.ToLower(),
            };

            using (var reader = new StreamReader(path))
            using (var csv = new CsvReader(reader, config))
            {
                csv.Context.RegisterClassMap<PartidoMap>();
                var records = csv.GetRecords<Partido>();
                int id = 1;
                foreach (var record in records)
                {
                    record.Id = id;
                    partidosHashTable.Add(id, record);
                    id++;
                }
            }

            return partidosHashTable;
        }

        public void GuardarTablaEnArchivo(string archivoRuta)
        {
            StringBuilder csv = new StringBuilder();

            // Encabezados del CSV
            string encabezado = "\"DateGMT\",\"Status\",\"Attendance\",\"HomeTeamName\",\"AwayTeamName\",\"Referee\",\"GameWeek\",\"PreMatchPPGHome\",\"PreMatchPPGAway\",\"HomePPG\",\"AwayPPG\",\"HomeTeamGoalCount\",\"AwayTeamGoalCount\",\"TotalGoalCount\",\"TotalGoalsAtHalfTime\",\"HomeTeamGoalCountHalfTime\",\"AwayTeamGoalCountHalfTime\",\"HomeTeamGoalTimings\",\"AwayTeamGoalTimings\",\"HomeTeamCornerCount\",\"AwayTeamCornerCount\",\"HomeTeamYellowCards\",\"HomeTeamRedCards\",\"AwayTeamYellowCards\",\"AwayTeamRedCards\",\"HomeTeamFirstHalfCards\",\"HomeTeamSecondHalfCards\",\"AwayTeamFirstHalfCards\",\"AwayTeamSecondHalfCards\",\"HomeTeamShots\",\"AwayTeamShots\",\"HomeTeamShotsOnTarget\",\"AwayTeamShotsOnTarget\",\"HomeTeamShotsOffTarget\",\"AwayTeamShotsOffTarget\",\"HomeTeamFouls\",\"AwayTeamFouls\",\"HomeTeamPossession\",\"AwayTeamPossession\",\"AverageGoalsPerMatchPreMatch\",\"AverageCornersPerMatchPreMatch\",\"AverageCardsPerMatchPreMatch\",\"OddsFtHomeTeamWin\",\"OddsFtDraw\",\"OddsFtAwayTeamWin\",\"StadiumName\"";
            csv.AppendLine(encabezado);

            // Obtener todos los partidos
            List<Partido> partidos = ObtenerTodos();

            // Iterar a través de cada partido
            foreach (var partido in partidos)
            {
                // Convertir los valores de las propiedades del partido a una línea CSV
                var line = string.Join(",", typeof(Partido).GetProperties().Where(prop => prop.Name != "Id").Select(prop => {
                    var value = prop.GetValue(partido);
                    if (value is string)
                    {
                        // Añadir comillas dobles si el valor es de tipo string
                        return $"\"{value}\"";
                    }
                    else if (value is DateTime)
                    {
                        // Formatear a "MMM dd yyyy - h:mmtt" y añadir comillas dobles si el valor es de tipo DateTime
                        return $"\"{((DateTime)value).ToString("MMM dd yyyy - h:mmtt", new CultureInfo("en-US"))}\"";
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
    }

    internal class PartidoMap : ClassMap<Partido>
    {
        public PartidoMap()
        {
            AutoMap(CultureInfo.InvariantCulture);
            Map(m => m.DateGMT).TypeConverter<DateTimeConverterCustom>();
            Map(m => m.Id).Ignore();
        }
    }

    public class DateTimeConverterCustom : DateTimeConverter
    {
        public override object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            DateTime dt;
            DateTime.TryParseExact(text, "MMM dd yyyy - h:mmtt", CultureInfo.InvariantCulture, DateTimeStyles.None, out dt);
            return dt;
        }
    }
}
