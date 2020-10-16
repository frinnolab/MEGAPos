using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MEGAPos.Models
{
    public class Stock_Take_Head
    {
        [Key]
        public int id { get; set; }


        [Display(Name = "Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? CheckDate { get; set; }

        public string CheckedBy { get; set; }

    }
}