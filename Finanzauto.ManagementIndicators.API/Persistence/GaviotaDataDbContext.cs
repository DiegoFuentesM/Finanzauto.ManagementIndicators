using Finanzauto.ManagementIndicators.API.Models;
using Microsoft.EntityFrameworkCore;

namespace Finanzauto.ManagementIndicators.API.Persistence
{
    public class GaviotaDataDbContext : DbContext
    {
        private const string API_SCHEMA = "GV";
        private const string LOG_SCHEMA = "LOG";
        public GaviotaDataDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(API_SCHEMA);
        }

        public DbSet<GaviotaData>? GaviotaData { get; set; }
    }
}
