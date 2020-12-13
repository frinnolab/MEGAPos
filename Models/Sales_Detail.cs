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

        public DateTime SaleDate { get; set; }

        public  string ItemName { get; set; }
        //public  string ItemCode { get; set; }

        public string CustomerName { get; set; }
        //public  string Description { get; set; }
        public int? Qty { get; set; }

        //public int? Qty_Available { get; set; }

        public decimal? Amount { get; set; }

        public decimal? AmountPaid { get; set; }

        public decimal? Cash_In { get; set; }

        //public int? Item_id { get; set; }

        public int? Sales_Header_id { get; set; }

        public int? UniId { get; set; }

        public string Unit_Name { get; set; }


        public int? Location_Id { get; set; }

        public string Location_Name { get; set; }
    }
}