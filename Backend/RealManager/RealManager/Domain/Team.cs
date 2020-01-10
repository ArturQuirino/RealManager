using System.Collections.Generic;

namespace RealManager.Domain
{
    public class Team
    {
        public string Name { get; set; }
        public List<Player> Players { get; set; }
        public List<Player> Starters { get;set; }
    }
}
