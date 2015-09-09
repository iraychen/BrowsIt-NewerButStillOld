using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BROWSit.Models
{
    // ENUM EXAMPLE
    /*public enum Grade
    {
        A, B, C, D, F
    }*/

    /*public class Enrollment
    {
        public int EnrollmentID { get; set; }
        public int CourseID { get; set; }
        public int StudentID { get; set; }
        public Grade? Grade { get; set; }
    }*/

    public class Test : BaseEntity
    {
        /***************
          Primary Key
        ***************/

        public int TestID { get; set; }

        /*********************
          Strings & Integers
        *********************/

        [Required]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Path")]
        public string Path { get; set; }

        /***********************
          Foreign Keys & Joins
        ***********************/

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
                        "Name",
                        "Path"
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
                        "Name",
                        "Path"
                    };
                return columnList;
            }
        }
    }
}