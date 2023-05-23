using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstadisticasDeportivas
{
    public class Equipo
    {
        [DisplayName("Nombre de Equipo")]
        public String teamName { get; set; }
        [DisplayName("Nombre comun")]
        public String commonName { get; set; }
        [DisplayName("Temporada")]
        public String season { get; set; }
        [DisplayName("Ciudad")]
        public String country { get; set; }
        [DisplayName("partidos jugados")]
        public int matchesPlayed { get; set; }
        [DisplayName("partidos suspendidos")]
        public int suspendedMatches { get; set; }
        [DisplayName("Ganados")]
        public int wins { get; set; }
        [DisplayName("Sorteos")]
        public int draws { get; set; }
        [DisplayName("Perdidos")]
        public int losses { get; set; }
        [DisplayName("Puntos por Juego")]
        public double pointsPerGame { get; set; }
        [DisplayName("Posición en la liga")]
        public int leaguePosition { get; set; }
        [DisplayName("Goles anotados")]
        public int goalsScored { get; set; }
        [DisplayName("Goles concedidos")]
        public int goalsConceded { get; set; }
        [DisplayName("Diferencia de gol")]
        public int goalDifference { get; set; }
        [DisplayName("Conteo total de goles")]
        public int totalGoalCount { get; set; }
        [DisplayName("Minutos por gol anotado")]
        public int minutesPerGoalScored { get; set; }
        [DisplayName("Minutos por gol cancelado")]
        public int minutesPerGoalConceded { get; set; }
        [DisplayName("Porteria Limpia")]
        public int cleanSheets { get; set; }
        [DisplayName("Primer equipo en anotar")]
        public int firstTeamToScoreCount { get; set; }
        [DisplayName("Total tiros de esquina")]
        public int cornersTotal { get; set; }
        [DisplayName("Total de tarjetas")]
        public int cardsTotal { get; set; }
        [DisplayName("Posesion Promedio")]
        public double averagePossession { get; set; }
        [DisplayName("Tiros")]
        public int shots { get; set; }
        [DisplayName("Tiros como local")]
        public int shotsHome { get; set; }
        [DisplayName("Tiros como visitante")]
        public int shotsAway { get; set; }
        [DisplayName("Tiros en el blanco")]
        public int shotsOnTarget { get; set; }
        [DisplayName("Tiros fuera")]
        public int shotsOffTarget { get; set; }
        [DisplayName("Faltas")]
        public int fouls { get; set; }
        [DisplayName("Faltas como local")]
        public int foulsHome { get; set; }
        [DisplayName("Faltas como visitante")]
        public int foulsAway { get; set; }
        [DisplayName("Goles marcados al medio tiempo")]
        public int goalsScoredHalfTime { get; set; }
        [DisplayName("Goles cancelados al medio tiempo")]
        public int goalsConcededHalfTime { get; set; }
        [DisplayName("Diferencia de goles medio tiempo")]
        public int goalDifferenceHalfTime { get; set; }
        [DisplayName("Liderando medio tiempo")]
        public int leadingAtHalfTime { get; set; }
        [DisplayName("Empate en el medio tiempo")]
        public int drawAtHalfTime { get; set; }
        [DisplayName("Perdiendo en el medio tiempo")]
        public int losingAtHalfTime { get; set; }
        [DisplayName("Promedio total de Goles por partido")]
        public double averageTotalGoalsPerMatch { get; set; }
        [DisplayName("Goles marcados por partido")]
        public double goalsScoredPerMatch { get; set; }
        [DisplayName("Goels cancelados por partido")]
        public double goalsConcededPerMatch { get; set; }
        [DisplayName("Total de goles por partido al medio tiempo")]
        public double totalGoalsPerMatchHalfTime { get; set; }
        [DisplayName("Toal de puntos por partido al medio tiempo")]
        public double goalsScoredPerMatchHalfTime { get; set; }
        [DisplayName("Goles Concedidos Por Partido Medio Tiempo")]
        public double goalsConcededPerMatchHalfTime { get; set; }
        [DisplayName("Porcentaje de victorias")]
        public int winPercentage { get; set; }
        [DisplayName("Porcentaje de ventaja en Casa")]
        public int homeAdvantagePercentage { get; set; }
        [DisplayName("Porcentaje de porteria limpia")]
        public int cleanSheetPercentage { get; set; }
        [DisplayName("Empate en porcentaje medio tiempo")]
        public int drawAtHalfTimePercentage { get; set; }
        [DisplayName("")]
        public double cornersPerMatch { get; set; }
        [DisplayName("Tiros de esquin por juego")]
        public double cardsPerMatch { get; set; }

        public override string ToString()
        {
            return $"Nombre: {this.teamName}, Temporada: {this.season}, Ciudad: {this.country}";
        }

    }

    
}
