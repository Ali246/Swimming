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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=UserManagementDb;Trusted_Connection=True;ConnectRetryCount=0");
            }
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
        public DbSet<AllRacingData> AllRacingDataTBL { get; set; }
        public DbSet<AllRacingDataFins> AllRacingFindDataTBL { get; set; }
        public DbSet<RACWITHCH> RACWITHCHTBL { get; set; }
        
    }
}
