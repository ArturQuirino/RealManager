using System.Collections.Generic;

namespace RealManager.Domain
{
    public class Event
    {
        public Event(Match match){
            HomeGoals = match.HomeGoals;
            AwayGoals = match.AwayGoals;
            Description = new List<string>();
        }
        public List<string> Description{get;set;}
        public int HomeGoals {get;set;}
        public int AwayGoals {get;set;}
    }
}