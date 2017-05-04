﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace jundie.net.core_pager.demo.models
{
    public class order
    {
        [Display(Name = "Order ID")]
        public int OrderId { get; set; }

        [Display(Name = "Customer ID"), StringLength(20)]
        public string CustomerId { get; set; }

        [Display(Name = "Order Date")]
        public DateTime OrderDate { get; set; }

        [Display(Name = "Company Name"), StringLength(20)]
        public string CompanyName { get; set; }

        [Display(Name = "Employee Name"), StringLength(20)]
        public string EmployeeName { get; set; }
    }
}
