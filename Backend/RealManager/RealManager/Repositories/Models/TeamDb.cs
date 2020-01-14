using System.Collections.Generic;

namespace RealManager.Repositories.Models
{
    public class TeamDb
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public List<string> Players { get; set; }
        public List<string> Starters { get;set; }
    }
}
