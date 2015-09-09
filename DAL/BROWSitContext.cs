using BROWSit.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace BROWSit.DAL
{
    public class BROWSitContext : DbContext
    {
        // Traditional BROWS tables
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<Prefix> Prefixes { get; set; }
        public DbSet<Target> Targets { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Test> Tests { get; set; }

        // New BROWSit tables
        public DbSet<Report> Reports { get; set; }





        // UNCOMMENT THIS TO REMOVE PLURALIZED TABLE NAMES
        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }*/
    }
}