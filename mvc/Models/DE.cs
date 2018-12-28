using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc.Models
{
    public class DE
    {
        public IEnumerable<Event> events { get; set; } //отфильтрованые

        public SelectList categories { get; set; }
    }
}