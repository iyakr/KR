using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace mvc.Models
{
    public class Event
    {
        [Key]
        public int event_Id { get; set; }
        [Required]
        public string event_name { get; set; }

        public int event_price { get; set; }



        public string event_info { get; set; }

        public string event_pict { get; set; }

        public DateTime event_date { get; set; }


        public string categ_name { get; set; }
        [ForeignKey("categ_name")]
        public virtual Category categories { get; set; }

        public string name_place { get; set; }
        [ForeignKey("name_place")]
        public virtual Place places { get; set; }

        public virtual ICollection<Purchase> purchases { get; set; }

        public Event()
        {
            purchases = new List<Purchase>();
        }

    }
}