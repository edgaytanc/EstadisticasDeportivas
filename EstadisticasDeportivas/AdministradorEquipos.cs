using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadisticasDeportivas
{
    internal class AdministradorEquipos
    {
        public static ArbolAVL LeerEquipos(string archivo)
        {
            ArbolAVL arbolEquipos = new ArbolAVL();

            try
            {
                using (StreamReader sr = new StreamReader(archivo))
                {
                    // Saltar la primera línea con los encabezados de las columnas
                    sr.ReadLine();

                    while (!sr.EndOfStream)
                    {
                        string linea = sr.ReadLine();
                        string[] campos = linea.Split(',');

                        // Crear un objeto Equipo con los datos de la línea actual
                        Equipo equipo = new Equipo
                        {
                            teamName = campos[0].Trim('"'),
                            commonName = campos[1].Trim('"'),
                            season = campos[2].Trim('"'),
                            country = campos[3].Trim('"'),
                            matchesPlayed = int.Parse(campos[4]),
                            suspendedMatches = int.Parse(campos[5]),
                            wins = int.Parse(campos[6]),
                            draws = int.Parse(campos[7]),
                            losses = int.Parse(campos[8]),
                            pointsPerGame = double.Parse(campos[9], CultureInfo.InvariantCulture),
                            leaguePosition = int.Parse(campos[10]),
                            goalsScored = int.Parse(campos[11]),
                            goalsConceded = int.Parse(campos[12]),
                            goalDifference = int.Parse(campos[13]),
                            totalGoalCount = int.Parse(campos[14]),
                            minutesPerGoalScored = int.Parse(campos[15]),
                            minutesPerGoalConceded = int.Parse(campos[16]),
                            cleanSheets = int.Parse(campos[17]),
                            firstTeamToScoreCount = int.Parse(campos[18]),
                            cornersTotal = int.Parse(campos[19]),
                            cardsTotal = int.Parse(campos[20]),
                            averagePossession = double.Parse(campos[21], CultureInfo.InvariantCulture),
                            shots = int.Parse(campos[22]),
                            shotsHome = int.Parse(campos[23]),
                            shotsAway = int.Parse(campos[24]),
                            shotsOnTarget = int.Parse(campos[25]),
                            shotsOffTarget = int.Parse(campos[26]),
                            fouls = int.Parse(campos[27]),
                            foulsHome = int.Parse(campos[28]),
                            foulsAway = int.Parse(campos[29]),
                            goalsScoredHalfTime = int.Parse(campos[30]),
                            goalsConcededHalfTime = int.Parse(campos[31]),
                            goalDifferenceHalfTime = int.Parse(campos[32]),
                            leadingAtHalfTime = int.Parse(campos[33]),
                            drawAtHalfTime = int.Parse(campos[34]),
                            losingAtHalfTime = int.Parse(campos[35]),
                            averageTotalGoalsPerMatch = double.Parse(campos[36], CultureInfo.InvariantCulture),
                            goalsScoredPerMatch = double.Parse(campos[37], CultureInfo.InvariantCulture),
                            goalsConcededPerMatch = double.Parse(campos[38], CultureInfo.InvariantCulture),
                            totalGoalsPerMatchHalfTime = double.Parse(campos[39], CultureInfo.InvariantCulture),
                            goalsScoredPerMatchHalfTime = double.Parse(campos[40], CultureInfo.InvariantCulture),
                            goalsConcededPerMatchHalfTime = double.Parse(campos[41], CultureInfo.InvariantCulture),
                            winPercentage = int.Parse(campos[42]),
                            homeAdvantagePercentage = int.Parse(campos[43]),
                            cleanSheetPercentage = int.Parse(campos[44]),
                            drawAtHalfTimePercentage = int.Parse(campos[45]),
                            cornersPerMatch = double.Parse(campos[46], CultureInfo.InvariantCulture),
                            cardsPerMatch = double.Parse(campos[47], CultureInfo.InvariantCulture),
                        };


                        // Agregar el equipo al arbol AVL
                        arbolEquipos.Insertar(equipo);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el archivo {archivo}: {ex.Message}");
            }

            return arbolEquipos;
        }

    }
}
