using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MEGAPos.Models
{
    public class Company
    {
        [key]
        public int Id { get; set; }

        public string Name { get; set; }

        public string Contact { get; set; }

        public string Email { get; set; }

        public int? Location_Id { get; set; }

        public string Location { get; set; }

        public int? CompanyTypeId { get; set; }

        public string Company_Type_Name { get; set; }
    }
}