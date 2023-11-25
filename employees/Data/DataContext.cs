using employees.Entities;
using Microsoft.EntityFrameworkCore;

namespace employees.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { 

        }

        public DbSet<Employees> Employees { get; set; }
    }
}
