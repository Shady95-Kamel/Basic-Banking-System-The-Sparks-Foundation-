using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Basic_Banking_System.Models
{
    public class Customer
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required, StringLength(30, MinimumLength = 3)]
        public string FirstName { get; set; }
        [Required, StringLength(30, MinimumLength = 3)]
        public string LastName { get; set; }
        [Required, EmailAddress, StringLength(50)]
        public string Email { get; set; }
        [Required]
        public double Balance { get; set; }

    }
}
