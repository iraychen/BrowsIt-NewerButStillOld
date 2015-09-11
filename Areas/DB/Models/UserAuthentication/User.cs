using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BROWSit.Models
{
    public class User : BaseEntityWithDate
    {
        /*********************
          Strings & Integers
        *********************/
        public string Username { get; set; }
        public string Hash { get; set; }
        public string Salt { get; set; }

        /***********************
          Foreign Keys & Joins
        ***********************/
        public virtual ICollection<Role> Roles { get; set; }
        public virtual ICollection<Report> Reports { get; set; }

        /*******************
          Helper Functions
        *******************/
        public static List<string> getDefaultColumns
        {
            get
            {
                List<string> columnList = new List<string>
                    {
                        "Username"
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
                        "Username"
                    };
                return columnList;
            }
        }
    }
}