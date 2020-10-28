using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEGAPos.Models
{
    public class DistributorTypes
    {
        [key]
        public int Id { get; set; }
        public string Distriutor_Name { get; set; }
    }
}