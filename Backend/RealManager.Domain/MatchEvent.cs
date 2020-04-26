using System;
using System.Collections.Generic;

namespace RealManager.Domain
{
    public class MatchEvent
    {
        public MatchEvent(Match match){
            if(match != null)
            {
                HomeGoals = match.HomeGoals;
                AwayGoals = match.AwayGoals;
                Description = new List<MatchEventDescription>();
            }
            else
            {
                throw new ArgumentNullException(nameof(match));
            }
        }

        public MatchEvent() { }

        public List<MatchEventDescription> Description{ get; set; }
        public int HomeGoals {get;set;}
        public int AwayGoals {get;set;}
    }
}