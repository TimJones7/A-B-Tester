using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    /*  The reason for the component table existing
     *  is to recompose one component at a time
     *  for analysis. 
     */
    
    public class Component
    {
        [Key]
        public int Id { get; set; }

        public string? Name { get; set; }

        [Required]
        [ForeignKey("Root")]
        public Guid ElementId { get; set; }
        [Required]
        public Element Root { get; set; }
    }
}
