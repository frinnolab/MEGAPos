using MEGAPos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEGAPos.ViewModels
{
    public class PriceListViewModel
    {
        public Item Item { get; set; }

        public List<PriceList> PriceLists { get; set; }
    }
}