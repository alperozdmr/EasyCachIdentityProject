﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyCachIdentityProject.EntityLayer.Concrete
{
    public class CustomerAccountProcess
    {
        public int CustomerAccountProcessId { get; set; }
        public string ProcessType { get; set; } = "";
        public decimal Amount { get; set;}
        public DateTime ProcessDate { get; set;}
        public int SenderID { get; set; }
        public int ReceiverID { get; set; }
        public string? Description { get; set; }
        public CustomerAccount SenderCustomer {  get; set; }
        public CustomerAccount ReceiverCustomer { get; set; }

    }
}
