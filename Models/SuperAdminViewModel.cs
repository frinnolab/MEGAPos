using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEGAPos.Models
{
    public class SuperAdminViewModel
    {
        public string user { get; set; }
        public List<ApplicationUser> users { get; set; }
        public List<IdentityRole> roles { get; set; }

        public List<Item> items { get; set; }

        public List<U_O_M> units { get; set; }

        public List<Sales_Header> Sales_Header { get; set; }
        public List<Sales_Detail> Sales_Details { get; set; }

        public List<Purchase_Head> Purchase_Head { get; set; }
        public List<Purchase_Detail> Purchase_Details { get; set; }

        public List<Company> Companies { get; set; }

        public List<CompanyType> CompanyTypes { get; set; }

        public List<Vendor> Vendors { get; set; }

        public List<ApplicationUser> Users { get; set; }









    }
}