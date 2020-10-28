using MEGAPos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEGAPos.ViewModels
{
    public class VendorViewModel
    {
        public List<Vendor> Vendors { get; set; }
        public List<VendorType> VendorTypes { get; set; }
        public List<Customers> Customers { get; set; }
        public List<CustomerType> CustomerTypes { get; set; }
    }
}