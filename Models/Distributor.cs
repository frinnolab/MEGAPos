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

        public string Email { get; set; }
        public string Address { get; set; }

        public string Contact { get; set; }

        public string User_Id { get; set; }

        public string Distributor_Name { get; set; }

        public int? Distributor_TypeID { get; set; }
    }
}