using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc.Models
{
    public class CEventsListViewModel
    {
        public IEnumerable<Event> events { get; set; } //отфильтрованые
       
        public SelectList places { get; set; }
    }
}