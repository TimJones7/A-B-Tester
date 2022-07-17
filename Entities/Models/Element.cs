using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Element
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string DomElement { get; set; }

        public string? HtmlId { get; set; }

        public string? Classes { get; set; }

        public string? Styles { get; set; }

        public string? Title { get; set; }

        public string? Value { get; set; }

        [ForeignKey("ParentElement")]
        public int? ParentId { get; set; }
        public Element? ParentElement { get; set; }

        [ForeignKey("FirstChild")]
        public int? FirstChildId { get; set; }
        public Element? FirstChild { get; set; }

        [ForeignKey("NextChild")]
        public int? NextChildId { get; set; }
        public Element? NextChild { get; set; }


        //  An element might appear in multiple sessions
        //      or have multiple customer interactions
        public ICollection<Session>? Sessions { get; set; }
        public ICollection<CustomerInteractions>? Interactions { get; set; }

        //  Potentially add property for storing the entire RAW HTML of an element?
        //  Or just the opening Tag Contents?
    }
}
