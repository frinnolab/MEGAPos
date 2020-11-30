using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEGAPos.Models
{
    public class Store_Location
    {
        [key]
        public int Id { get; set; }

        public string StoreName { get; set; }
    }
}