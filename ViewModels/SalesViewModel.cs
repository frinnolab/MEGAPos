using MEGAPos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEGAPos.ViewModels
{
    public class SalesViewModel
    {
        public Sales_Header sales_Header { get; set; }

        public List<Sales_Detail> sales_Details { get; set; }

        public List<CreditSales> creditSales { get; set; }

    }
}