using Microsoft.EntityFrameworkCore;
using TaskManager_Kylosov.Classes.Database;
using TaskManager_Kylosov.Models;

namespace TaskManager_Kylosov.Context
{
    public class PriorityContext : DbContext
    {
        public DbSet<Priority> Priority { get; set; }
        public PriorityContext()
        {
            Database.EnsureCreated();
            this.Priority.Load();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql(Config.connection, Config.version);
        }
    }
}
