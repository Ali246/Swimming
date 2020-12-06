using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Swimming.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Participants> Participant { get; set; }
        public DbSet<CaptainOrOrganization> CaptainOrOrganizations { get; set; }
        public DbSet<Cities> City { get; set; }
        public DbSet<Racing> Racings { get; set; }
        public DbSet<RacingDetails> RacingDetail { get; set; }
        public DbSet<Points> Point { get; set; }
        public DbSet<Championship> CSChampionships { get; set; }
        public DbSet<ChampionshipDetails> CSDChampionshipDetails { get; set; }
        public DbSet<ChampionShipwithRacing> CWRChampionShipwithRacing { get; set; }
    }
}
