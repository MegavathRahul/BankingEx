using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

#nullable disable

namespace BankingEx.EFModels
{
    public partial class Customer
    {
        public Customer()
        {
            Accounts = new HashSet<Account>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "Name is Required")]
        [MaxLength(10)]
        public string Name { get; set; }
        [Required]
        //[Range(typeof(DateTime), "1/1/1996", "1/1/2021", ErrorMessage = "Date of birth must be between 1/1/1996 and 1/1/2021")]
        public DateTime Dob { get; set; }
        [Required]
        [MaxLength(10)]
        [RegularExpression("[A-Z]{5}[0-9]{4}[A-Z]{1}")]
        public string PanNumber { get; set; }
        [Required]
        public string City { get; set; }

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
