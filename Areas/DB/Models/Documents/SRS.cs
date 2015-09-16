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
        public string Purpose { get; set; }

        /***********************
          Foreign Keys & Joins
        ***********************/
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
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