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
    public class RequirementArea : BaseEntity
    {
        /*********************
          Strings & Integers
        *********************/
        public string Name { get; set; }

        /***********************
          Foreign Keys & Joins
        ***********************/
        public int? SRSID { get; set; }
        public virtual SRS SRS { get; set; }

        public virtual ICollection<Requirement> Requirements { get; set; }

        /*******************
          Helper Functions
        *******************/
        public static List<string> getDefaultColumns
        {
            get
            {
                List<string> columnList = new List<string>
                    {
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
                    };
                return columnList;
            }
        }
    }

    public class RequirementAreaConfiguration : EntityTypeConfiguration<RequirementArea>
    {
        public RequirementAreaConfiguration()
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