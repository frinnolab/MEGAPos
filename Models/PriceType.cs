using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MEGAPos.Models
{
    public class PriceType
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public int? Unit_Id { get; set; }

        public string Unit_Name { get; set; }

        public int? ItemCount { get; set; }
    }
}