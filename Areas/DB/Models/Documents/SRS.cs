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
    public class SRS : BaseEntityWithDate
    {
        /*********************
          Strings & Integers
        *********************/
        public string Filename { get; set; }
        public string ProductLine { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int Version { get; set; }
        public string SoftwareReuse { get; set; }
        public string FutureUses { get; set; }
        public string Interactions { get; set; }

        /***********************
          Foreign Keys & Joins
        ***********************/
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<RequirementArea> RequirementAreas { get; set; }

        /*******************
          Helper Functions
        *******************/
        public static List<string> getDefaultColumns
        {
            get
            {
                List<string> columnList = new List<string>
                    {
                        "Filename",
                        "ProductLine",
                        "Title",
                        "Author",
                        "Version",
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
                        "Filename",
                        "ProductLine",
                        "Title",
                        "Author",
                        "Version",
                        "SoftwareReuse",
                        "FutureUses",
                        "Interactions",
                        "CreationDate",
                        "ModificationDate"
                    };
                return columnList;
            }
        }
    }
}