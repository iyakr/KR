using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using mvc.Context;
using mvc.Models;
using System.Data.Entity;

namespace mvc.Controllers
{
    public class HomeController : Controller
    {
        mvcContext db = new mvcContext();


        public ActionResult Index()
        {

            return View();
        }

        public ActionResult About(string event_namee)
        {
            ViewBag.Message = "Все мероприятия";

            var s= db.events.Include(categ_name => categ_name.categories).Include(name_place => name_place.places).AsQueryable();
            var filterdata = s.Where(i => DateTime.Compare(i.event_date, DateTime.Now) <= 0);
            //ss.Select(p => p.event_name).Distinct();

            

            return View(filterdata); //связанные данные 
            
          
        }

        public ActionResult Contact()
        {
            

            return View();
        }

       
        public ActionResult Search(string place)
        {
           

            IQueryable<Event> eventss = db.events.Include(p => p.places);
            
           
            if (!String.IsNullOrEmpty(place) && !place.Equals("Все"))
            {
                eventss = eventss.Where(p => p.name_place == place);

            }
            

            CEventsListViewModel clvm = new CEventsListViewModel
            {
                events = eventss.ToList(),
                  places = new SelectList(new List<string>()
                {
                    "Все",
                   "Ивановская государственная филармония",
                   "Ивановский областной драматический театр",
                   "Ивановский областной художественный музей",
                   "ГЦКиО Ивтекс",
                   "Стадион Текстильщик",
                   "Музей ивановского ситца",
                   "Ивановский областной музыкальный театр",
                   "Ивановский государственный цирк"

                })



            };
            return View(clvm);
        }

        public ActionResult katego(string category)
        {


            IQueryable<Event> eventss = db.events.Include(p => p.categories);


            if (!String.IsNullOrEmpty(category) && !category.Equals("Все"))
            {
                eventss = eventss.Where(p => p.categ_name == category);

            }


            DE qwe = new DE
            {
                events = eventss.ToList(),
                categories = new SelectList(new List<string>()
                {
                    "Все",
                   "Кино",
                   "Театр",
                   "Цирк",
                   "Музыка",
                   "Музеи",
                   "Спорт"

                })



            };
            return View(qwe);
        }







    }
}
    
        
  