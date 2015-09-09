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
    public class Report : BaseEntity
    {
        /***************
          Primary Key
        ***************/

        public int ReportID { get; set; }

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
        [StringLength(200)]
        [Display(Name = "Query")]
        public string Query { get; set; }

        /***********************
          Foreign Keys & Joins
        ***********************/

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
                        "Query",
                        "CreationDate",
                        "ModificationDate"
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
                        "Query",
                        "CreationDate",
                        "ModificationDate"
                    };
                return columnList;
            }
        }
    }
}