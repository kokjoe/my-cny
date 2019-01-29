using Microsoft.EntityFrameworkCore;
using my_cny.API.Model;

namespace my_cny.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
        public DbSet<Patient> Patients { get; set; }
    }
}