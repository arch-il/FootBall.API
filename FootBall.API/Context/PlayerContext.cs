using Microsoft.AspNetCore.Mvc;

namespace FootBall.API.Context
{
    using Microsoft.EntityFrameworkCore;
    using FootBall.API.Models;
    public sealed class PlayerContext : DbContext
    {
        public DbSet<Player> player { get; set; }
        public PlayerContext(DbContextOptions<PlayerContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
    }
}

