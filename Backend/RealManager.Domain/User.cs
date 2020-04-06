using System;

namespace RealManager.Domain
{
    public class User
    {
        public User()
        {
            Id = Guid.NewGuid();
        }
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Guid TeamId { get; set; }
    }
}
