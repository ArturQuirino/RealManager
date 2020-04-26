using System;
using System.ComponentModel.DataAnnotations;

namespace RealManager.Repositories.Models
{
    public class LeagueDb
    {
        public Guid Id { get; set; }
        public Guid IdLeague { get; set; }
        public int Season { get; set; }
        public int Position { get; set; }
        public Guid TeamId { get; set; }
        public string TeamName { get; set; }
        public int Matches { get; set; }
        public int Won { get; set; }
        public int Drawn { get; set; }
        public int Lost { get; set; }
        public int GoalsFor { get; set; }
        public int GoalsAgainst { get; set; }
        public int GoalDifference { get; set; }
        public int Points { get; set; }
    }
}
