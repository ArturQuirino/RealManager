using System;
using System.Collections.Generic;

namespace RealManager.Repositories.Models
{
    public class MatchEventDescriptionDb
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public Guid MatchEventId { get; set; }
        public int Position { get; set; }
    }
}
