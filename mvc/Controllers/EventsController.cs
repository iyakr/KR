using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using mvc.Context;
using mvc.Models;

namespace mvc.Controllers
{
    public class EventsController : Controller
    {
        private mvcContext db = new mvcContext();

        // GET: Events
        [Authorize ]
        public ActionResult Index()
        {
            var events = db.events.Include(categ_name => categ_name.categories).Include(name_place => name_place.places);

            return View(events.ToList()); //связанные данные 
        }

        // GET: Events/Details/5
       
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }

        // GET: Events/Create
        
        public ActionResult Create()
        {
            ViewBag.categ_name = new SelectList(db.categories, "categ_name", "categ_name");
            ViewBag.name_place = new SelectList(db.places, "name_place", "name_place");
            return View();
        }

        // POST: Events/Create
       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "event_Id,event_name,event_price,event_info,event_date,categ_name,name_place")] Event @event, HttpPostedFileBase UploadImage)
        {
            if (ModelState.IsValid)
            {
                if (UploadImage != null)
                {
                    if (UploadImage.ContentType == "image/jpg" || UploadImage.ContentType == "image/png"
                        || UploadImage.ContentType == "image/jpeg")
                    {
                        UploadImage.SaveAs(Server.MapPath("/") + "/Content/" + UploadImage.FileName);
                        @event.event_pict = UploadImage.FileName;
                    }
                    //else
                    //    return View();

                }
                
                    //return View();
                db.events.Add(@event);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.categ_name = new SelectList(db.categories, "categ_name", "categ_name", @event.categ_name);
            ViewBag.name_place = new SelectList(db.places, "name_place", "name_place", @event.name_place);
            return View(@event);
        }
    
        // GET: Events/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            ViewBag.categ_name = new SelectList(db.categories, "categ_name", "categ_name", @event.categ_name);
            ViewBag.name_place = new SelectList(db.places, "name_place", "name_place", @event.name_place);
            return View(@event);
        }
        
        // POST: Events/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "event_Id,event_name,event_price,event_info,event_pict,event_date,categ_name,name_place")] Event @event)
        {
            if (ModelState.IsValid)
            {
                db.Entry(@event).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.categ_name = new SelectList(db.categories, "categ_name", "categ_name", @event.categ_name);
            ViewBag.name_place = new SelectList(db.places, "name_place", "name_place", @event.name_place);
            return View(@event);
        }
       
        // GET: Events/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event @event = db.events.Find(id);
            if (@event == null)
            {
                return HttpNotFound();
            }
            return View(@event);
        }
        
        // POST: Events/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event @event = db.events.Find(id);
            db.events.Remove(@event);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
