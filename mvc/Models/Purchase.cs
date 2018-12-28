using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public class Purchase
    {
        [Key]
        public int pursh_Id { get; set; }

        public virtual ICollection<Event> events { get; set; }

        public Purchase()
        {
            events = new List<Event>();
        }

    }
}