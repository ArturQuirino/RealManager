﻿using RealManager.Domain.Enums;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace RealManager.Domain
{
    public class Player
    {
        public Player()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get;set; }
        public string Name { get;set; }
        public int Pace { get; set; }
        public int Shoot { get; set; }
        public int Pass { get; set; }
        public int Drible { get; set; }
        public int Defence { get; set; }
        public int Physical { get; set; }
        public Position Position { get;set; }
        public Guid TeamId { get;set; }
        public int Overall { get; set; }
    }
}
