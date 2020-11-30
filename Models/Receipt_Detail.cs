using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MEGAPos.Models
{
    public class Receipt_Detail
    {
        [Key]
        public int Id { get; set; }

        public string Item_Name { get; set; }

        public decimal? QtySold { get; set; }

        public decimal? AmountCost { get; set; }

        public decimal? AmountPaid { get; set; }

        public int? Receipt_Head_Id { get; set; }
    }
}