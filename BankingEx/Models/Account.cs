﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BankingEx.Models
{
    public class Account
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public int Type { get; set; }
        public Customer Customer { get; set; }

    }
}
