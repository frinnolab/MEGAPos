using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEGAPos.Models
{
    public class StockWatch
    {
        public int Id { get; set; }
        public int? ItemId { get; set; }

        public string ItemName { get; set; }

        public decimal? QtyIn { get; set; }

        public decimal? QtyOut { get; set; }

        public decimal? QtyBalance { get; set; }

        public decimal? BuyingPrice { get; set; }

        public decimal? SellingPrice { get; set; }

        public int? UnitId { get; set; }

        public string UnitName { get; set; }

        public int? PurchaseId { get; set; }
        public int? SalesId { get; set; }
    }
}