﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoEduardoAnacletoWindowsForm1.Models
{
    public class BillsToReceive : Identifications
    {

        public BillsToReceive()
        {
            People person = new People();
            PaymentMethods paymentForms = new PaymentMethods();
            Sales sale = new Sales();
            BillsInstalments billInstalment = new BillsInstalments();
        }

        public int isPaid { get; set; }
        public Sales sale { get; set; }
        public People person { get; set; }
        public PaymentMethods paymentForm { get; set; }
        public BillsInstalments billInstalment { get; set; }
        public DateTime dueDate { get; set; }
        public DateTime emissionDate { get; set; }
        public double instalmentValue { get; set; }


    }
}