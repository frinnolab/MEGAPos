using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEGAPos.Models
{
    public class VAT
    {
        [key]
        public int Id { get; set; }

        public string Name { get; set; }

        public decimal? Value { get; set; }

    }
}