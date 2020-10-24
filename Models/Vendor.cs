using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEGAPos.Models
{
    public class Vendor
    {
        [key]
        public int Id { get; set; }
        public string User_Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public int? Vendor_TypeID { get; set; }
    }
}