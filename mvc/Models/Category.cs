using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace mvc.Models
{
    public class Category
    {
        public Category()
        {
            this.events = new HashSet<Event>();
        }
        [Required]
        [Key]
        public string categ_name { get; set; }
       
        public virtual ICollection<Event> events { get; set; }


    }
}