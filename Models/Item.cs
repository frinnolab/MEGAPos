﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MEGAPos.Models
{
    public class Item
    {
        [Key]

        public int Id { get; set; }
        public string Item_Name { get; set; }
        public string Description { get; set; }

        public decimal? Qty_In { get; set; }

        public string Created_By { get; set; }

        [Display(Name = "Created Date")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? ItemDateCreated { get; set; }
        [Display(Name = "Last Update")]
        [DisplayFormat(DataFormatString = "{0:dd-MM-yyyy}")]
        public DateTime? ItemDateUpdate { get; set; }
    }
}