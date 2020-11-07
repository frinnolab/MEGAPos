using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MEGAPos.Models
{
    public class Sales_Header
    {
        [Key]
        public int Id { get; set; }
        public DateTime Sale_Date { get; set; }

        public string Seller_Id { get; set; }

        public string Seller_Name { get; set; }

        public string CustomerName { get; set; }

        public int? CustomerType_Id { get; set; }
        public string CustomerType_Name { get; set; }



    }
}