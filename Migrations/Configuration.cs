namespace BROWSit.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using BROWSit.Models;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.SqlServer;
    using System.Data.Entity.Migrations.Model;
    using BROWSit.Helpers;

    internal sealed class Configuration : DbMigrationsConfiguration<BROWSit.DAL.BROWSitContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            AutomaticMigrationDataLossAllowed = true;
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
            // TRACE
            context.Requirements.AddOrUpdate(
                r => r.Title,
                new Requirement() { Title = "TestRequirement01", Author = "TestAuthor01", Rationale = "TestRationale01" },
                new Requirement() { Title = "TestRequirement02", Author = "TestAuthor02", Rationale = "TestRationale02" },
                new Requirement() { Title = "TestRequirement03", Author = "TestAuthor03", Rationale = "TestRationale03" },
                new Requirement() { Title = "TestRequirement04", Author = "TestAuthor04", Rationale = "TestRationale04" },
                new Requirement() { Title = "TestRequirement05", Author = "TestAuthor05", Rationale = "TestRationale05" }
            );

            context.Platforms.AddOrUpdate(
                p => p.Name,
                new Platform() { Name = "TestPlatform01" },
                new Platform() { Name = "TestPlatform02" },
                new Platform() { Name = "TestPlatform03" }
            );

            context.Targets.AddOrUpdate(
                t => t.Name,
                new Target() { Name = "TestTarget01" },
                new Target() { Name = "TestTarget02" },
                new Target() { Name = "TestTarget03" }
            );

            context.Features.AddOrUpdate(
                f => f.Name,
                new Feature() { Name = "TestFeature01" },
                new Feature() { Name = "TestFeature02" },
                new Feature() { Name = "TestFeature03" }
            );

            // USERAUTHENTICATION
            context.Roles.AddOrUpdate(
                r => r.Name,
                new Role() { Name = "TestRole01" },
                new Role() { Name = "TestRole02" }
            );

            LoginHelper.PasswordManager pm1 = new LoginHelper.PasswordManager("TestUser01", "password");
            LoginHelper.PasswordManager pm2 = new LoginHelper.PasswordManager("TestUser02", "password2");
            context.Users.AddOrUpdate(
                u => u.Username,
                new User() { Username = pm1.username, Hash = pm1.hash.getHashString(), Salt = pm1.salt.getSaltString() },
                new User() { Username = pm2.username, Hash = pm2.hash.getHashString(), Salt = pm2.salt.getSaltString() }
            );

            // DOCUMENTS
            context.Reports.AddOrUpdate(
                r => r.Title,
                new Report() { Title = "TestReport01", Author = "Seed", Query = "SELECT * FROM REQUIREMENTS" },
                new Report() { Title = "TestReport02", Author = "Seed", Query = "SELECT * FROM PLATFORMS" },
                new Report() { Title = "TestReport03", Author = "Seed", Query = "SELECT * FROM NOTHING" }
            );

            context.SRS.AddOrUpdate(
                s => s.Title,
                new SRS() { Title = "TestSRS01", Author = "Seed", Path = "?" },
                new SRS() { Title = "TestSRS02", Author = "Seed", Path = "?" }
            );

            context.PRS.AddOrUpdate(
                r => r.Title,
                new PRS() { Title = "TestPRS01", Author = "Seed", Path = "?" },
                new PRS() { Title = "TestPRS02", Author = "Seed", Path = "?" }
            );

            context.TestScripts.AddOrUpdate(
                t => t.Title,
                new TestScript() { Title = "Test01", Author = "Seed", Path = "?" },
                new TestScript() { Title = "Test02", Author = "Seed", Path = "?" }
            );
        }
    }
}
