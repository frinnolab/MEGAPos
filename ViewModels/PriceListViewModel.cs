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

        public List<PriceList> WholeSalePriceItems { get; set; }

        public List<PriceList> RetailPriceItems { get; set; }
    }
}