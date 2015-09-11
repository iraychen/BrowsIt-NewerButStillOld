using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;

namespace BROWSit.Models
{
    public class Requirement : BaseEntityWithDate
    {
        /*********************
          Strings & Integers
        *********************/
        public string Title { get; set; }
        public string Author { get; set; }
        public string Rationale { get; set; }

        /***********************
          Foreign Keys & Joins
        ***********************/
        public int? TargetID { get; set; }
        public virtual Target Target { get; set; }

        public int? SRSID { get; set; }
        public virtual SRS SRS { get; set; }

        public virtual ICollection<Platform> Platforms { get; set; }
        public virtual ICollection<TestScript> TestScripts { get; set; }

        /*******************
          Helper Functions
        *******************/
        public static List<string> getDefaultColumns
        {
            get
            {
                List<string> columnList = new List<string>
                    {
                        "Title",
                        "Author",
                        "Rationale"
                    };
                return columnList;
            }
        }

        public static List<string> getAllColumns
        {
            get
            {
                List<string> columnList = new List<string>
                    {
                        "ID",
                        "Title",
                        "Author",
                        "Rationale",
                        "CreationDate",
                        "ModificationDate"
                    };
                return columnList;
            }
        }
    }

    public class RequirementConfiguration : EntityTypeConfiguration<Requirement>
    {
        public RequirementConfiguration()
        {
            // Map entities to tables (to change table names from class names)
            // modelBuilder.Entity<Requirement>().ToTable("RequirementTableName");

            // Configure primary keys (if not [ID] or ClassName+[ID])
            //modelBuilder.Entity<Requirement>().HasKey<int>(x => x.ID);
            //modelBuilder.Entity<Membership>().HasKey<int>(x => new { x.UserID, x.RoleID });

            // Configure column names, types, and orders
            //modelBuilder.Entity<Requirement>().Property(x => x.Title)
            //.HasColumnName("Title")
            //.HasColumnOrder(1)
            //.HasColumnType("")
            //;

            // Configure null/NotNull (isoptional, isrequired)
            //modelBuilder.Entity<Requirement>().Property(x => x.Title).IsRequired();

            // Configure column sizes (isfixedlength for nvarchar to nchar, hasprecision (2,2) for decimal (2,2))
            //modelBuilder.Entity<Requirement>().Property(x => x.Title).HasMaxLength(50);
        }
    }
}