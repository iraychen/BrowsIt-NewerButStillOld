using BROWSit.Models;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;

namespace BROWSit.DAL
{
    public class BROWSitContext : DbContext
    {
        // DB Initialization Strategy
        public BROWSitContext()
        {
            //Database.SetInitializer<BROWSitContext>(new CreateDatabaseIfNotExists<BROWSitContext>());
            //Database.SetInitializer<BROWSitContext>(new DropCreateDatabaseIfModelChanges<BROWSitContext>());
            //Database.SetInitializer<BROWSitContext>(new DropCreateDatabaseAlways<BROWSitContext>());
            //Database.SetInitializer<BROWSitContext>(new BROWSitDBInitializer());
            //Database.SetInitializer(new MigrateDatabaseToLatestVersion<BROWSitContext, Migrations.Configuration>());
            Database.SetInitializer<BROWSitContext>(null);
        }

        // TRACE Tables
        public DbSet<Requirement> Requirements { get; set; }
        public DbSet<Target> Targets { get; set; }
        public DbSet<Platform> Platforms { get; set; }
        public DbSet<Feature> Features { get; set; }

        // Documents tables
        public DbSet<Report> Reports { get; set; }
        public DbSet<PRS> PRS { get; set; }
        public DbSet<SRS> SRS { get; set; }
        public DbSet<TestScript> TestScripts { get; set; }

        // User Authentication tables
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }

        // Using Fluent API...
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // Configure default schema (???)
            //modelBuilder.HasDefaultSchema("Admin");

            // Set custom configurations for the entities that need it
            modelBuilder.Configurations.Add(new RequirementConfiguration());

            // Set one-to-many relationships (necessary if fk id doesn't follow ClassId convention)
            /* Do this in separate configurations or here (???) */
            //modelBuilder.Entity<Target>().HasMany<Requirement>(t => t.Requirements).WithRequired(r => r.Target).HasForeignKey(t => t.TargetID);
            modelBuilder.Entity<SRS>().HasMany<Requirement>(s => s.Requirements).WithOptional(r => r.SRS).HasForeignKey(r => r.SRSID);
            modelBuilder.Entity<Target>().HasMany<Requirement>(t => t.Requirements).WithOptional(r => r.Target).HasForeignKey(r => r.TargetID);

            // Set many-to-many relationships (super useful!)
            modelBuilder.Entity<Requirement>().HasMany<Platform>(r => r.Platforms).WithMany(p => p.Requirements)
                .Map(rp => { 
                    rp.MapLeftKey("RequirementID");
                    rp.MapRightKey("PlatformID");
                    rp.ToTable("AppliesTo");
                });

            modelBuilder.Entity<Requirement>().HasMany<TestScript>(r => r.TestScripts).WithMany(t => t.Requirements)
                .Map(tb =>
                {
                    tb.MapLeftKey("RequirementID");
                    tb.MapRightKey("TestScriptID");
                    tb.ToTable("TestedBy");
                });

            modelBuilder.Entity<User>().HasMany<Report>(u => u.Reports).WithMany(r => r.Users)
                .Map(m =>
                {
                    m.MapLeftKey("UserID");
                    m.MapRightKey("ReportID");
                    m.ToTable("UserCanEdit");
                });

            modelBuilder.Entity<Role>().HasMany<Report>(r => r.Reports).WithMany(r => r.Roles)
                .Map(m =>
                {
                    m.MapLeftKey("RoleID");
                    m.MapRightKey("ReportID");
                    m.ToTable("RoleCanEdit");
                });

            base.OnModelCreating(modelBuilder);
        }


        // UNCOMMENT THIS TO REMOVE PLURALIZED TABLE NAMES
        /*protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }*/
    }
}