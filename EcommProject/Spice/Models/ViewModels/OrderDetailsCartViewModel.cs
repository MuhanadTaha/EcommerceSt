﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Spice.Models.ViewModels
{
    public class OrderDetailsCartViewModel
    {
        public List<ShoppingCart> ShoppingCartList { get; set; }
        public OrderHeader OrderHeader { get; set; }


    }
}
