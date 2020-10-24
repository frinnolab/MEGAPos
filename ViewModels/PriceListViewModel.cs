using MEGAPos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEGAPos.ViewModels
{
    public class PriceListViewModel
    {
        public int Item_id { get; set; }
        public string ItemName { get; set; }

        public decimal WholeSalePrice { get; set; }

        public decimal RetailPrice { get; set; }
    }
}