﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinallyProjectDATA.Models.ViewModels
{
    public class OrderStateViewModel
    {
        public int OrderId { get; set; }
        public string OrderNumber { get; set; }
        public bool IsCompleted { get; set; }
    }
}
