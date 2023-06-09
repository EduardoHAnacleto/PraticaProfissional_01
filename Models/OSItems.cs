﻿using ProjetoEduardoAnacletoWindowsForm1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEduardoAnacletoWindowsForm1.Next
{
    public class OSItems : Identifications
    {
        public OSItems()
        {
           Products Product = new Products();
        }

        public int OSId { get; set; }
        public Products Product { get; set; }
        public int Quantity { get; set; }
        public double ProductValue { get; set; }
        public double TotalValue { get; set; }
        public double ProductCost { get; set; }
        public double ItemDiscountCash { get; set; }
        public double ItemDiscountPerc { get; set; }

    }
}
