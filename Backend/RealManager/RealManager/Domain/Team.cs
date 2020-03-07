using System;
using System.Collections.Generic;

namespace RealManager.Domain
{
    public class Team
    {
        public Team()
        {
            Id = Guid.NewGuid();
            Players = new List<Player>();
            Starters = new List<Player>();
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Player> Players { get; set; }
        public List<Player> Starters { get;set; }
    }
}
