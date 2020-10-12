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

        public int? Seller_Id { get; set; }

        public int? Buyer_Id { get; set; }

    }
}