using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadisticasDeportivas
{
    internal class AdministradorJugadores
    {
        public static ListaEnlazadaJugadores LeerJugadores(string archivo)
        {
            ListaEnlazadaJugadores listaJugadores = new ListaEnlazadaJugadores();

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

                       

                        // Crear un objeto Jugador con los datos de la línea actual
                        Jugador jugador = new Jugador
                        {
                            FullName = campos[0].Trim('"'),
                            Age = int.Parse(campos[1]),
                            Birthday = DateTime.ParseExact(campos[2].Trim('"'), "yyyy/MM/dd", CultureInfo.InvariantCulture),
                            League = campos[3].Trim('"'),
                            Season = campos[4].Trim('"'),
                            Position = campos[5].Trim('"'),
                            Club = campos[6].Trim('"'),
                            MinutesPlayedOverall = int.Parse(campos[7]),
                            MinutesPlayedHome = int.Parse(campos[8]),
                            MinutesPlayedAway = int.Parse(campos[9]),
                            Nationality = campos[10].Trim('"'),
                            AppearancesOverall = int.Parse(campos[11]),
                            AppearancesHome = int.Parse(campos[12]),
                            AppearancesAway = int.Parse(campos[13]),
                            GoalsOverall = int.Parse(campos[14]),
                            GoalsHome = int.Parse(campos[15]),
                            GoalsAway = int.Parse(campos[16]),
                            AssistsOverall = int.Parse(campos[17]),
                            AssistsHome = int.Parse(campos[18]),
                            assistsAway = int.Parse(campos[19]),
                            PenaltyGoals = int.Parse(campos[20]),
                            PenaltyMisses = int.Parse(campos[21]),
                            CleanSheetsOverall = int.Parse(campos[22]),
                            CleanSheetsHome = int.Parse(campos[23]),
                            CleanSheetsAway = int.Parse(campos[24]),
                            ConcededOverall = int.Parse(campos[25]),
                            ConcededHome = int.Parse(campos[26]),
                            ConcededAway = int.Parse(campos[27]),
                            YellowCardsOverall = int.Parse(campos[28]),
                            RedCardsOverall = int.Parse(campos[29]),
                            GoalsInvolvedPer90Overall = double.Parse(campos[30], CultureInfo.InvariantCulture),
                            AssistsPer90Overall = double.Parse(campos[31], CultureInfo.InvariantCulture),
                            GoalsPer90Overall = double.Parse(campos[32], CultureInfo.InvariantCulture),
                            GoalsPer90Home = double.Parse(campos[33], CultureInfo.InvariantCulture),
                            GoalsPer90Away = double.Parse(campos[34], CultureInfo.InvariantCulture),
                            MinPerGoalOverall = int.Parse(campos[35]),
                            ConcededPer90Overall = double.Parse(campos[36], CultureInfo.InvariantCulture),
                            MinPerConcededOverall = int.Parse(campos[37]),
                            MinPerMatch = int.Parse(campos[38]),
                            MinPerCardOverall = int.Parse(campos[39]),
                            MinPerAssistOverall = int.Parse(campos[40]),
                            CardsPer90Overall = double.Parse(campos[41], CultureInfo.InvariantCulture),
                            RankInLeagueTopAttackers = int.Parse(campos[42]),
                            RankInLeagueTopMidfielders = int.Parse(campos[43]),
                            RankInLeagueTopDefenders = int.Parse(campos[44]),
                            RankInClubTopScorer = int.Parse(campos[45])
                        };

                        // Agregar el jugador a la lista enlazada
                        listaJugadores.AgregarJugador(jugador);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error al leer el archivo {archivo}: {ex.Message}");
            }

            return listaJugadores;
        }

    }
}
