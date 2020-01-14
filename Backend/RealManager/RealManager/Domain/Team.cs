using System;
using System.Collections.Generic;

namespace RealManager.Domain
{
    public class Team
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public List<Player> Players { get; set; }
        public List<Player> Starters { get;set; }
    }
}
