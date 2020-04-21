using System;
using System.Collections.Generic;

namespace RealManager.Repositories.Models
{
    public class MatchEventDb
    {
        public Guid Id { get; set; }
        public int HomeGoals { get; set; }
        public int AwayGoals { get; set; }
        public Guid MatchId { get; set; }
    }
}
