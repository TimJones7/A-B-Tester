using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Session
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [Required]
        public Customer Customer { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public bool ResultedInOrder { get; set; }
        
        public double? TotalSpent { get; set; }


        public ICollection<CustomerInteractions> Interactions { get; set; }

        //  Many to many
        //      One session can have many elements
        //      One element can be in multiple sessions
        public ICollection<Element> Elements { get; set; }
    }
}
