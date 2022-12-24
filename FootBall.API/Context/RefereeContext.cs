using Microsoft.AspNetCore.Mvc;

namespace FootBall.API.Context
{
    using Microsoft.EntityFrameworkCore;
    using FootBall.API.Entities;
    public sealed class RefereeContext : DbContext
    {
        public DbSet<Referee> referee { get; set; }
        public RefereeContext(DbContextOptions<RefereeContext> options)
            : base(options)
        {
            this.Database.EnsureCreated();
        }
    }
}

