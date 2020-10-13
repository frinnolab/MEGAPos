using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MEGAPos.Models
{
    public class Purchase_Head
    {
        [Key]
        public int id { get; set; }
        public int? Vendor_Id { get; set; }

        public string Purchased_by { get; set; }

        [Display(Name = "Purchase Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? Purchase_Date { get; set; }

    }
}