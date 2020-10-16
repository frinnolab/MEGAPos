using MEGAPos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEGAPos.ViewModels
{
    public class StockTakeViewModel
    {
        public Item Item { get; set; }

        public List<U_O_M> Units { get; set; }

    }
}