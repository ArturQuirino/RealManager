using System;
using System.Collections.Generic;

namespace RealManager.Repositories.Models
{
    public class TeamDb
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid Starter1Id { get; set; }
        public Guid Starter2Id { get; set; }
        public Guid Starter3Id { get; set; }
        public Guid Starter4Id { get; set; }
        public Guid Starter5Id { get; set; }
        public Guid Starter6Id { get; set; }
        public Guid Starter7Id { get; set; }
        public Guid Starter8Id { get; set; }
        public Guid Starter9Id { get; set; }
        public Guid Starter10Id { get; set; }
        public Guid Starter11Id { get; set; }
        public List<PlayerDb> Players { get; set; }
    }
}
