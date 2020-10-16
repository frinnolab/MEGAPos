using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MEGAPos.Models
{
    public class Stock_Take_Detail
    {
        [Key]
        public int id { get; set; }

        public int? Item_id { get; set; }

        public decimal? QuantityChecked { get; set; }

        public int? UOM_id { get; set; }

        public int? Stock_Take_Head_id { get; set; }


    }
}