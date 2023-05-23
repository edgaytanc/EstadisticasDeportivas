using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadisticasDeportivas
{
    public class Jugador
    {
        [DisplayName("Nombre Completo")]
        public string FullName { get; set; }
        [DisplayName("Edad")]
        public int Age { get; set; }
        [DisplayName("Cumpleaños")]
        public DateTime Birthday { get; set; }
        [DisplayName("Liga")]
        public string League { get; set; }
        [DisplayName("Temporada")]
        public string Season { get; set; }
        [DisplayName("Posicion")]
        public string Position { get; set; }
        [DisplayName("Club")]
        public string Club { get; set; }
        [DisplayName("Minutos jugados en general")]
        public int MinutesPlayedOverall { get; set; }
        [DisplayName("Minutos jugados como local")]
        public int MinutesPlayedHome { get; set; }
        [DisplayName("Minutos jugados como visitante")]
        public int MinutesPlayedAway { get; set; }
        [DisplayName("Nacionalidad")]
        public string Nationality { get; set; }
        [DisplayName("Apariciones en general")]
        public int AppearancesOverall { get; set; }
        [DisplayName("Apariciones como local")]
        public int AppearancesHome { get; set; }
        [DisplayName("Apariciones como visitante")]
        public int AppearancesAway { get; set; }
        [DisplayName("Goles en General")]
        public int GoalsOverall { get; set; }
        [DisplayName("Goles como local")]
        public int GoalsHome { get; set; }
        [DisplayName("Goles como visitante")]
        public int GoalsAway { get; set; }
        [DisplayName("Asistencias en general")]
        public int AssistsOverall { get; set; }
        [DisplayName("Asistencias como local")]
        public int AssistsHome { get; set; }
        [DisplayName("Asistencias como visitante")]
        public int assistsAway { get; set; }
        [DisplayName("Goles de penalti")]
        public int PenaltyGoals { get; set; }
        [DisplayName("Faltas de penalti")]
        public int PenaltyMisses { get; set; }
        [DisplayName("Porteria Limpia en general")]
        public int CleanSheetsOverall { get; set; }
        [DisplayName("Porteria Limpia como local")]
        public int CleanSheetsHome { get; set; }
        [DisplayName("Porteria Limpia como visitante")]
        public int CleanSheetsAway { get; set; }
        [DisplayName("Concedidos en general")]
        public int ConcededOverall { get; set; }
        [DisplayName("Concedidos como locales")]
        public int ConcededHome { get; set; }
        [DisplayName("Concedidos como visitantes")]
        public int ConcededAway { get; set; }
        [DisplayName("Tarjetas amarillas en general")]
        public int YellowCardsOverall { get; set; }
        [DisplayName("Tarjetas rojas en general")]
        public int RedCardsOverall { get; set; }
        [DisplayName("Goles involucrados por 90 General")]
        public double GoalsInvolvedPer90Overall { get; set; }
        [DisplayName("Asistencias por 90 General")]
        public double AssistsPer90Overall { get; set; }
        [DisplayName("Goles por 90 en General")]
        public double GoalsPer90Overall { get; set; }
        [DisplayName("Goles por 90 locales")]
        public double GoalsPer90Home { get; set; }
        [DisplayName("Goles por 90 visitante")]
        public double GoalsPer90Away { get; set; }
        [DisplayName("Minimo por gol en general")]
        public int MinPerGoalOverall { get; set; }
        [DisplayName("Concesiones por 90 General")]
        public double ConcededPer90Overall { get; set; }
        [DisplayName("Minimo conceciones General")]
        public int MinPerConcededOverall { get; set; }
        [DisplayName("Minutos por partido")]
        public int MinPerMatch { get; set; }
        [DisplayName("Minutos por tarjeta general")]
        public int MinPerCardOverall { get; set; }
        [DisplayName("Minutos por asistencia General")]
        public int MinPerAssistOverall { get; set; }
        [DisplayName("Tarjetas por 90 General")]
        public double CardsPer90Overall { get; set; }
        [DisplayName("Los mejores atacantes de la Liga")]
        public int RankInLeagueTopAttackers { get; set; }
        [DisplayName("Los mejores centro campista de la liga")]
        public int RankInLeagueTopMidfielders { get; set; }
        [DisplayName("Los mejores defensores de la liga")]
        public int RankInLeagueTopDefenders { get; set; }
        [DisplayName("Maximo anotador por club")]
        public int RankInClubTopScorer { get; set; }

        public override string ToString()
        {
            return $"Nombre: {this.FullName}, Edad: {this.Age}, Club: {this.Club}";
        }


    }
}
