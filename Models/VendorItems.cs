using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEGAPos.Models
{
    public class VendorItems
    {
        [key]
        public int Id { get; set; }
        public int? Vendor_Id { get; set; }
        public int? Item_Id { get; set; }

        public string Item_Name { get; set; }

        public decimal? QuantityBal { get; set; }

        public int? unit_id { get; set; }
        public string Unit_Name { get; set; }

        public int? Vendor_TypeID { get; set; }

    }
}