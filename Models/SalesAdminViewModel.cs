using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEGAPos.Models
{
    public class SalesAdminViewModel
    {
        public string user { get; set; }

        public List<ApplicationUser> users { get; set; }
    }
}