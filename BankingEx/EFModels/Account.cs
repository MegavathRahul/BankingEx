using System;
using System.Collections.Generic;

#nullable disable

namespace BankingEx.EFModels
{
    public partial class Account
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public decimal Balance { get; set; }
        public bool Type { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
    }
}
