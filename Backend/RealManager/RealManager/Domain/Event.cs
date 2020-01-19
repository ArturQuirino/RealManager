using System.Collections.Generic;

namespace RealManager.Domain
{
    public class Event
    {
        public List<string> Description{get;set;}
        public int HomeGoals {get;set;}
        public int AwayGoals {get;set;}
    }
}