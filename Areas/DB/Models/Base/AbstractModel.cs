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
    public class BaseEntityWithDate
    {
        /***************
          Primary Key
        ***************/

        public int ID { get; set; }

        /********
          Dates
        ********/

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreationDate { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime ModificationDate { get; set; }
    }

    public class BaseEntity
    {
        /***************
          Primary Key
        ***************/

        public int ID { get; set; }
    }
}