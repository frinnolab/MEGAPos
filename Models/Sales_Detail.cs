using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MEGAPos.Models
{
    public class Sales_Detail
    {
        [Key]
        public int Id { get; set; }

        public  string ItemName { get; set; }
        public  string ItemCode { get; set; }
        public  string Description { get; set; }
        public int? Qty { get; set; }

        public int? Qty_Available { get; set; }

        public decimal? Price { get; set; }

        public int? Item_id { get; set; }

        public int? Sales_Header_id { get; set; }
    }
}