using MEGAPos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEGAPos.ViewModels
{
    public class PurchaseViewModel
    {
        public Purchase_Head Purchase_Head { get; set; }

        public List<Purchase_Detail> Purchase_Details { get; set; }

    }
}