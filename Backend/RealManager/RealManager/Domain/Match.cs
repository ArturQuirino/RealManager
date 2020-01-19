using System;
using System.Collections.Generic;

namespace RealManager.Domain
{
    public class Match
    {
        public Guid Id { get;set; }
        public Guid HomeTeamId { get;set; }
        public Guid AwayTeamId { get;set; }
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }
        public string FinalResult { 
            get{
                return HomeGoals.ToString() + " : " + AwayGoals.ToString();
            }
            set{
                FinalResult = value;
            }
        }
        public List<Event> Events { get; set; }
    }
}
