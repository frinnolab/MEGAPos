using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MEGAPos.Models
{
    public class SalesType
    {
        [Key]
        public int Id { get; set; }

        public string SaleName { get; set; }
    }
}