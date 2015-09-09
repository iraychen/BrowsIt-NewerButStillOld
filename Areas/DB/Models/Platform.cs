using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BROWSit.Models
{
    public class Platform : BaseEntity
    {
        /***************
          Primary Key
        ***************/

        public int PlatformID { get; set; }

        /*********************
          Strings & Integers
        *********************/

        [Required]
        [StringLength(50)]
        [Display(Name = "Name")]
        public string Name { get; set; }

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
                        "Name"
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
                        "Name"
                    };
                return columnList;
            }
        }
    }
}