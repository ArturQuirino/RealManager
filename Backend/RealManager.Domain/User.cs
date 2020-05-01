using Newtonsoft.Json;
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
        [JsonIgnore]
        public string Password { get; set; }
        public Guid TeamId { get; set; }
        public string Token { get; set; }
    }
}
