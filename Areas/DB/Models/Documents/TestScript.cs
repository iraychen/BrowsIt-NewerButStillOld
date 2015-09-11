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
    public class TestScript : BaseEntityWithDate
    {
        /*********************
          Strings & Integers
        *********************/
        public string Title { get; set; }
        public string Author { get; set; }
        public string Path { get; set; }

        /***********************
          Foreign Keys & Joins
        ***********************/
        public virtual ICollection<Requirement> Requirements { get; set; }
        public virtual ICollection<User> Users { get; set; }
        public virtual ICollection<Role> Roles { get; set; }

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