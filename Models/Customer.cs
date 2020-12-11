using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MEGAPos.Models
{
    public class Customer
    {
        [Key]
        public int id { get; set; }

        public string Customer_Name { get; set; }

        public string Address { get; set; }

        public string Contact { get; set; }

        public string Created_By { get; set; }

        public int? CustomerType_Id { get; set; }

    }
}