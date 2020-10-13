using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MEGAPos.Models
{
    public class Purchase_Detail
    {
        [Key]
        public int id { get; set; }

        public int? Item_id { get; set; }

        public decimal? Qunatity_In { get; set; }

        public decimal? Price { get; set; }

        public int? Purchase_Head_id { get; set; }
        public int? Unit_id { get; set; }

        public string Unit_Name { get; set; }

    }
}