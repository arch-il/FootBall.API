using Microsoft.AspNetCore.Mvc;

namespace FootBall.API.Context
{
    using Microsoft.EntityFrameworkCore;
    using FootBall.API.Entities;
    public sealed class UserContext : DbContext
    {
        public DbSet<Player> player { get; set; }
        public DbSet<Referee> referee { get; set; }
        public DbSet<Team> team { get; set; }
        public DbSet<Stadium> stadium { get; set; }
        public UserContext(DbContextOptions<UserContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
    }
}

