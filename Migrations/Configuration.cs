namespace BROWSit.Migrations
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BROWSit.Models;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.SqlServer;
    using System.Data.Entity.Migrations.Model;

    internal sealed class Configuration : DbMigrationsConfiguration<BROWSit.DAL.BROWSitContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            SetSqlGenerator("System.Data.SqlClient", new CustomSqlServerMigrationSqlGenerator());
        }

        internal class CustomSqlServerMigrationSqlGenerator : SqlServerMigrationSqlGenerator
        {
            // https://andy.mehalick.com/2014/02/06/ef6-adding-a-created-datetime-column-automatically-with-code-first-migrations
            protected override void Generate(AddColumnOperation add)
            {
                SetCreatedUtcColumn(add.Column);
                base.Generate(add);
            }

            protected override void Generate(CreateTableOperation create)
            {
                SetCreatedUtcColumn(create.Columns);
                base.Generate(create);
            }

            private static void SetCreatedUtcColumn(IEnumerable<ColumnModel> columns)
            {
                foreach (var columnModel in columns)
                {
                    SetCreatedUtcColumn(columnModel);
                }
            }

            private static void SetCreatedUtcColumn(PropertyModel column)
            {
                if (column.Name == "CreationDate")
                {
                    column.DefaultValueSql = "GETUTCDATE()";
                }
                if (column.Name == "ModificationDate")
                {
                    column.DefaultValueSql = "GETUTCDATE()";
                }
            }
        }

        protected override void Seed(BROWSit.DAL.BROWSitContext context)
        {
            var prefixes = new List<Prefix>
            {
                new Prefix
                {
                    Name = "TestPrefix01",
                    Document = "TestDoc01"
                },
                new Prefix
                {
                    Name = "TestPrefix02",
                    Document = "TestDoc02"
                },
                new Prefix
                {
                    Name = "TestPrefix03",
                    Document = "TestDoc03"
                },
                new Prefix
                {
                    Name = "TestPrefix04",
                    Document = "TestDoc04"
                },
                new Prefix
                {
                    Name = "TestPrefix05",
                    Document = "TestDoc05"
                }
            };
            prefixes.ForEach(s => context.Prefixes.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var targets = new List<Target>
            {
                new Target
                {
                    Name = "TestTarget01"
                },
                new Target
                {
                    Name = "TestTarget02"
                },
                new Target
                {
                    Name = "TestTarget03"
                },
                new Target
                {
                    Name = "TestTarget04"
                },
                new Target
                {
                    Name = "TestTarget05"
                }
            };
            targets.ForEach(s => context.Targets.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var platforms = new List<Platform>
            {
                new Platform
                {
                    Name = "TestPlatform01"
                },
                new Platform
                {
                    Name = "TestPlatform02"
                },
                new Platform
                {
                    Name = "TestPlatform03"
                }
            };
            platforms.ForEach(s => context.Platforms.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var tests = new List<Test>
            {
                new Test
                {
                    Name = "TestName01",
                    Path = "TestPath01"
                },
                new Test
                {
                    Name = "TestName02",
                    Path = "TestPath02"
                },
                new Test
                {
                    Name = "TestName03",
                    Path = "TestPath03"
                }
            };
            tests.ForEach(s => context.Tests.AddOrUpdate(p => p.Name, s));
            context.SaveChanges();

            var requirements = new List<Requirement>
            {
                new Requirement 
                {   
                    Title = "TestRequirement01", 
                    Author = "AutomaticSeed",
                    Rationale = "Because",
                    PrefixID = prefixes.Single(s => s.Name == "TestPrefix01").PrefixID,
                    TargetID = targets.Single(s => s.Name == "TestTarget01").TargetID
                },
                new Requirement 
                {   
                    Title = "TestRequirement02", 
                    Author = "AutomaticSeed",
                    Rationale = "Because",
                    PrefixID = prefixes.Single(s => s.Name == "TestPrefix01").PrefixID,
                    TargetID = targets.Single(s => s.Name == "TestTarget01").TargetID
                },
                new Requirement 
                {   
                    Title = "TestRequirement03", 
                    Author = "AutomaticSeed",
                    Rationale = "Because",
                    PrefixID = prefixes.Single(s => s.Name == "TestPrefix01").PrefixID,
                    TargetID = targets.Single(s => s.Name == "TestTarget01").TargetID
                },
                new Requirement 
                {   
                    Title = "TestRequirement04", 
                    Author = "AutomaticSeed",
                    Rationale = "Because",
                    PrefixID = prefixes.Single(s => s.Name == "TestPrefix01").PrefixID,
                    TargetID = targets.Single(s => s.Name == "TestTarget01").TargetID
                },
                new Requirement 
                {   
                    Title = "TestRequirement05", 
                    Author = "AutomaticSeed",
                    Rationale = "Because",
                    PrefixID = prefixes.Single(s => s.Name == "TestPrefix01").PrefixID,
                    TargetID = targets.Single(s => s.Name == "TestTarget01").TargetID
                },
                new Requirement 
                {   
                    Title = "TestRequirement06", 
                    Author = "AutomaticSeed",
                    Rationale = "Because",
                    PrefixID = prefixes.Single(s => s.Name == "TestPrefix01").PrefixID,
                    TargetID = targets.Single(s => s.Name == "TestTarget01").TargetID
                }
            };
            requirements.ForEach(r => context.Requirements.AddOrUpdate(p => p.Title, r));
            context.SaveChanges();

            var reports = new List<Report>
            {
                new Report
                {
                    Title = "TestReport01", 
                    Author = "AutomaticSeed",
                    Query = "Because",
                },
                new Report
                {
                    Title = "TestReport02",
                    Author = "AutomaticSeed",
                    Query = "Because",
                }
            };
            reports.ForEach(s => context.Reports.AddOrUpdate(p => p.Title, s));
            context.SaveChanges();
        }
    }
}
