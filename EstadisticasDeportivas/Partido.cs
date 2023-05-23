using System;
using System.ComponentModel;

namespace EstadisticasDeportivas
{
    public class Partido
    {
        public int Id { get; set; }
        [DisplayName("Fecha")]
        public DateTime DateGMT { get; set; }
        [DisplayName("Estado")]
        public string Status { get; set; }
        [DisplayName("")]
        public int Attendance { get; set; }
        [DisplayName("")]
        public string HomeTeamName { get; set; }
        [DisplayName("")]
        public string AwayTeamName { get; set; }
        [DisplayName("")]
        public string Referee { get; set; }
        [DisplayName("")]
        public int GameWeek { get; set; }
        [DisplayName("")]
        public double PreMatchPPGHome { get; set; }
        [DisplayName("")]
        public double PreMatchPPGAway { get; set; }
        [DisplayName("")]
        public double HomePPG { get; set; }
        [DisplayName("")]
        public double AwayPPG { get; set; }
        [DisplayName("")]
        public int HomeTeamGoalCount { get; set; }
        [DisplayName("")]
        public int AwayTeamGoalCount { get; set; }
        [DisplayName("")]
        public int TotalGoalCount { get; set; }
        [DisplayName("")]
        public int TotalGoalsAtHalfTime { get; set; }
        [DisplayName("")]
        public int HomeTeamGoalCountHalfTime { get; set; }
        [DisplayName("")]
        public int AwayTeamGoalCountHalfTime { get; set; }
        [DisplayName("")]
        public string HomeTeamGoalTimings { get; set; }
        [DisplayName("")]
        public string AwayTeamGoalTimings { get; set; }
        [DisplayName("")]
        public int HomeTeamCornerCount { get; set; }
        [DisplayName("")]
        public int AwayTeamCornerCount { get; set; }
        [DisplayName("")]
        public int HomeTeamYellowCards { get; set; }
        [DisplayName("")]
        public int HomeTeamRedCards { get; set; }
        [DisplayName("")]
        public int AwayTeamYellowCards { get; set; }
        [DisplayName("")]
        public int AwayTeamRedCards { get; set; }
        [DisplayName("")]
        public int HomeTeamFirstHalfCards { get; set; }
        [DisplayName("")]
        public int HomeTeamSecondHalfCards { get; set; }
        [DisplayName("")]
        public int AwayTeamFirstHalfCards { get; set; }
        [DisplayName("")]
        public int AwayTeamSecondHalfCards { get; set; }
        [DisplayName("")]
        public int HomeTeamShots { get; set; }
        [DisplayName("")]
        public int AwayTeamShots { get; set; }
        [DisplayName("")]
        public int HomeTeamShotsOnTarget { get; set; }
        [DisplayName("")]
        public int AwayTeamShotsOnTarget { get; set; }
        [DisplayName("")]
        public int HomeTeamShotsOffTarget { get; set; }
        [DisplayName("")]
        public int AwayTeamShotsOffTarget { get; set; }
        [DisplayName("")]
        public int HomeTeamFouls { get; set; }
        [DisplayName("")]
        public int AwayTeamFouls { get; set; }
        [DisplayName("")]
        public int HomeTeamPossession { get; set; }
        [DisplayName("")]
        public int AwayTeamPossession { get; set; }
        [DisplayName("")]
        public double AverageGoalsPerMatchPreMatch { get; set; }
        [DisplayName("")]
        public double AverageCornersPerMatchPreMatch { get; set; }
        [DisplayName("")]
        public double AverageCardsPerMatchPreMatch { get; set; }
        [DisplayName("")]
        public double OddsFtHomeTeamWin { get; set; }
        [DisplayName("")]
        public double OddsFtDraw { get; set; }
        [DisplayName("")]
        public double OddsFtAwayTeamWin { get; set; }
        [DisplayName("")]
        public string StadiumName { get; set; }
        

        public override string ToString()
        {
            return $"DateGMT: {DateGMT}, Status: {Status}, HomeTeamName: {HomeTeamName}, AwayTeamName: {AwayTeamName}";  // y los demás campos...
        }

    }
}
