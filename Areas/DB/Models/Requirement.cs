using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BROWSit.Models
{
    public class Requirement : BaseEntity
    {
        /***************
          Primary Key
        ***************/

        public int ID { get; set; }

        /*********************
          Strings & Integers
        *********************/

        [Required]
        [StringLength(50)]
        [Display(Name = "Title")]
        public string Title { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Author")]
        public string Author { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Rationale")]
        public string Rationale { get; set; }

        //public int PRSID { get; set; }

        /***********************
          Foreign Keys & Joins
        ***********************/
        public int PrefixID { get; set; }
        public virtual Prefix Prefix { get; set; }

        public int TargetID { get; set; }
        public virtual Target Release { get; set; }

        public virtual ICollection<Platform> Platforms { get; set; }
        public virtual ICollection<Test> Tests { get; set; }

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
                        "ModificationDate",
                        "Prefix",
                        "Target"
                    };
                return columnList;
            }
        }
    }
}