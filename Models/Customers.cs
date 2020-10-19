using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MEGAPos.Models
{
    public class Customers
    {
        [Key]
        public int id { get; set; }

        public string Customer_Name { get; set; }

        public string Address { get; set; }

        public string Contact { get; set; }

    }
}