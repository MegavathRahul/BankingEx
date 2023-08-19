using System;
using System.Collections.Generic;

#nullable disable

namespace BankingEx.EFModels
{
    public partial class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
    }
}
