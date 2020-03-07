﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RealManager.Repositories.Models
{
    public class PlayerDb
    {
        public Guid Id { get;set; }
        public string Name { get;set; }
        public int Pace { get; set; }
        public int Shoot { get; set; }
        public int Pass { get; set; }
        public int Drible { get; set; }
        public int Defence { get; set; }
        public int Physical { get; set; }
        public int Position { get; set; }
        public Guid TeamId { get; set; }
    }
}
