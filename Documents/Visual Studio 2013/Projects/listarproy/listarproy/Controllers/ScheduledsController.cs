using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using listarproy.Models;

namespace listarproy.Controllers
{
    public class ScheduledsController : Controller
    {
        private listarproyContext db = new listarproyContext();

        // GET: Scheduleds
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Listuser = id.Value;
            try
            {
                ViewBag.Until = DateTime.Now;
                ViewBag.Until = db.Scheduleds.Where(item => item.list == id.Value).Single(item1 => item1.Until == db.Scheduleds.Where(item => item.list == id.Value).Max(item => item.Until)).Until;
                }catch(Exception e){

                }
            return View(db.Scheduleds.Where(item => item.list == id.Value).ToList());
        }

        // GET: Scheduleds/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scheduled scheduled = db.Scheduleds.Find(id);
            if (scheduled == null)
            {
                return HttpNotFound();
            }
            return View(scheduled);
        }

        // GET: Scheduleds/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Listuser = id.Value;
            return View();
        }

        // POST: Scheduleds/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Until,list,Finished")] Scheduled scheduled)
        {
            if (ModelState.IsValid)
            {
                var lists = scheduled.list;
                db.Database.ExecuteSqlCommand(@"UPDATE listas SET Checked=0 WHERE list = {0} ", lists);
                db.Scheduleds.Add(scheduled);
                db.SaveChanges();
                return RedirectToAction("Index", new { id = scheduled.list });
            }

            return View(scheduled);
        }

        // GET: Scheduleds/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scheduled scheduled = db.Scheduleds.Find(id);
            if (scheduled == null)
            {
                return HttpNotFound();
            }
            return View(scheduled);
        }

        // POST: Scheduleds/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Until,list,Finished")] Scheduled scheduled)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scheduled).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new { id = scheduled.list });
            }
            return View(scheduled);
        }

        // GET: Scheduleds/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Scheduled scheduled = db.Scheduleds.Find(id);
            if (scheduled == null)
            {
                return HttpNotFound();
            }
            ViewBag.Listuser = scheduled.list;
            return View(scheduled);
        }

        // POST: Scheduleds/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Scheduled scheduled = db.Scheduleds.Find(id);
            db.Scheduleds.Remove(scheduled);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = scheduled.list });
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
