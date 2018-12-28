using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public class Place
    {
        [Key]
        public string name_place { get; set; }

        public string addres_place { get; set; }

        public string place_info { get; set; }

        public int telefon_place { get; set; }

        public virtual ICollection<Event> events { get; set; }
    }
}