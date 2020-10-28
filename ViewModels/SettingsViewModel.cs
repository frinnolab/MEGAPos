using MEGAPos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEGAPos.ViewModels
{
    public class SettingsViewModel
    {
        public List<SalesType> SalesTypes { get; set; }
        public List<Distributor> Distributors { get; set; }
        public List<DistributorType> DistributorTypes { get; set; }
    }
}