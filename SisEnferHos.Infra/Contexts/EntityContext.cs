using Flunt.Notifications;
using Microsoft.EntityFrameworkCore;
using SistEnferHos.Domain.Entities;
using SistEnferHos.Infra.EntitiesMaps;
using SistEnferHos.Infra.Helpers;

namespace SistEnferHos.Infra.Contexts
{
    public class EntityContext : DbContext
    {
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Nurse> Nurses { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HospitalMap());
            modelBuilder.ApplyConfiguration(new NurseMap());
            modelBuilder.Ignore<Notification>();

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            ReadJsonSettings readJsonSettings = new ReadJsonSettings();
            optionsBuilder.UseSqlServer(readJsonSettings.ConnectionString());
        }
    }
}
