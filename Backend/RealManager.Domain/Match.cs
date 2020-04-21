using System;
using System.Collections.Generic;
using System.Globalization;

namespace RealManager.Domain
{
    public class Match
    {
        public Match(Guid homeTeamId, string homeTeamName, Guid awayTeamId, string awayTeamName){
            Id = Guid.NewGuid();
            HomeTeamId = homeTeamId;
            AwayTeamId = awayTeamId;
            HomeTeamName = homeTeamName;
            AwayTeamName = awayTeamName;
            HomeGoals = 0;
            AwayGoals = 0;
            Events = new List<MatchEvent>();
        }

        public Match() { }
        
        public Guid Id { get;set; }
        public Guid HomeTeamId { get;set; }
        public Guid AwayTeamId { get;set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }
        public string FinalResult { 
            get{
                return HomeTeamName + " " +  HomeGoals.ToString(new CultureInfo("en-US")) + " : " + AwayGoals.ToString(new CultureInfo("en-US")) + " " + AwayTeamName;
            }
            set{
                FinalResult = value;
            }
        }
        public List<MatchEvent> Events { get; set; }
    }
}
