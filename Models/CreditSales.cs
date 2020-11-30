using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEGAPos.Models
{
    public class CreditSales
    {
        [key]
        public int Id { get; set; }

        public DateTime SaleDate { get; set; }

        public int? ItemId { get; set; }

        public string Item_Name { get; set; }

        public decimal? QtySold { get; set; }

        public decimal? AmountCost { get; set; }

        public decimal? AmountPaid { get; set; }

        public decimal? AmountBalance { get; set; }

        public decimal? TotalBalance { get; set; }

        public decimal? AmountTotal { get; set; }

        public decimal? Cash_In { get; set; }
        public int? UniId { get; set; }

        public string Unit_Name { get; set; }

        public int? CusTypeId { get; set; }

        public string CusTypeName { get; set; }

        public string Customer_Name { get; set; }
        public int? Sales_Header_id { get; set; }

    }
}