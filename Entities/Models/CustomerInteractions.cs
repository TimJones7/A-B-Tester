using Entities.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class CustomerInteractions
    {
        [Required]
        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
        [Required]
        public Customer Customer { get; set; }


        [Required]
        [ForeignKey("Session")]
        public int SessionId { get; set; }
        [Required]
        public Session Session { get; set; }


        [Required]
        [ForeignKey("Element")]
        public Guid ElementId { get; set; }
        [Required]
        public Element Element { get; set; }


        [Required]
        public CustomerAction Action { get; set; }

        [Required]
        public DateTime OccuranceDateTime { get; set; }

    }
}