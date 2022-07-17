using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }
        
        //  -Get Required Info From Domino's Website.
        //  -Come back later and write custom validations
        //      for the hell of it just to combine them
        //      and for writing custom validations sake
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        [EmailAddress]
        [MaxLength(75)]
        public string Email { get; set; }
        [Phone]
        [Required]
        public string Phone { get; set; }



        //  Customer can have many sessions and many interactions

        public ICollection<Session>? Sessions { get; set; }
        public ICollection<CustomerInteractions>? Interactions { get; set; }

    }
}
