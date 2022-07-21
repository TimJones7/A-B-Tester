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
        public Guid? Id { get; set; }

        public bool IsRoot { get; set; }

        public string? NodeType { get; set; }

        
        public string? HtmlId { get; set; }

        public string? HtmlClasses { get; set; }

        public string? HtmlStyles { get; set; }

        public string? HtmlName { get; set; }

        public string? HtmlValue { get; set; }

        
        
        public Guid? ParentId { get; set; }
        public Guid? FirstChildId { get; set; }        
        public Guid? NextSiblingId { get; set; }


        //  An element might appear in multiple sessions
        //      or have multiple customer interactions
        public ICollection<Session>? Sessions { get; set; }
        public ICollection<CustomerInteractions>? Interactions { get; set; }

        //  Potentially add property for storing the entire RAW HTML of an element?
        //  Or just the opening Tag Contents?
    }
}
