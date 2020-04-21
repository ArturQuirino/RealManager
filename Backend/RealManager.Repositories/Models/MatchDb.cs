using System;
using System.Collections.Generic;

namespace RealManager.Repositories.Models
{
    public class MatchDb
    {
        public Guid Id { get; set; }
        public Guid HomeTeamId { get; set; }
        public Guid AwayTeamId { get; set; }
        public string HomeTeamName { get; set; }
        public string AwayTeamName { get; set; }
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }
        public string FinalResult { get; set; }
    }
}
