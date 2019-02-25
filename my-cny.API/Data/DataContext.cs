using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using my_cny.API.Model;

namespace my_cny.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
        public DbSet<Patient> Patients { get; set; }
        public DbSet<CurrentMRN> CurrentMRNs { get; set; }
        public DbSet<EmergencyContact> EmergencyContacts { get; set; }
        public DbSet<Identification> Identifications { get; set; }
        public DbSet<Relationship> Relationships { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public int MyProperty { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<Patient>().Property<string>("CreatedBy");
            builder.Entity<Relationship>().Property<string>("CreatedBy");
        }

        public override int SaveChanges()
        {
            var modifiedEntries = ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified);

            foreach (EntityEntry entry in modifiedEntries)
            {
                var entityType = entry.Context.Model.FindEntityType(entry.Entity.GetType());

                var createdProperty = entityType.FindProperty("CreatedBy");

                if (entry.State == EntityState.Added && createdProperty != null)
                {
                    entry.Property("CreatedBy").CurrentValue = "Admin";
                }
            }
            return base.SaveChanges();
        }
    }
}