using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Basic_Banking_System.Models
{
    public class TransferVM
    {
        [Required]
        public Customer Sender { get; set; }
        public int ReceiverId { get; set; }
        public IEnumerable<Customer> Receivers { get; set; }
        [Required]
        public double Amount { get; set; }
    }
}
