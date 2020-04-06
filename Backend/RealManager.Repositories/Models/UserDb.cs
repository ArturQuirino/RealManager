using System;

namespace RealManager.Repositories.Models
{
    public class UserDb
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid TeamId { get; set; }
    }
}
