using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEGAPos.Models
{
    public class PriceList
    {
        [key]
        public int Id { get; set; }

        public int? Item_Id { get; set; }

        public int? PriceType_Id { get; set; }

        public decimal? PriceValue { get; set; }
    }
}