using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MEGAPos.Models
{
    public class Distributor
    {
        [Key]
        public int id { get; set; }

        public string CompanyName { get; set; }
        public string Address { get; set; }

        public string Contact { get; set; }

        public string Distirbutor_Id { get; set; }

        public string Distributor_Name { get; set; }
    }
}