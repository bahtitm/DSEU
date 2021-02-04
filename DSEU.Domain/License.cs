using System;

namespace DSEU.Domain
{
    public class License
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int UsersCount { get; set; }
        public bool IsTrial { get; set; }
        public DateTime? Expiration { get; set; }
    }
}
