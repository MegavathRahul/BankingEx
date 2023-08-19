using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BankingEx.Models
{
    public class Customer
    {
        public int Id { get; set; }
        
        public string Name { get; set; }
        public DateTime DoB { get; set; }
        public string PAN { get; set; }
        public string City { get; set; }


    }
}
