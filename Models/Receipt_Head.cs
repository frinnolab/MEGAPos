using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEGAPos.Models
{
    public class Receipt_Head
    {
        [key]
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string CustomerName { get; set; }
        public string StoreLocationName { get; set; }
        public decimal? AmountTotal { get; set; }
    }
}