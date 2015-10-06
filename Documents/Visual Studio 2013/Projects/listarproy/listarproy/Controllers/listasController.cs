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
    public class listasController : Controller
    {
        private listarproyContext db = new listarproyContext();
        public int list;
        // GET: listas
        public ActionResult Index(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }   ViewBag.ListuserName = db.ListUsers.Find(id).Name;
                ViewBag.Listuser = id.Value;
                try
                {
                    ViewBag.listLength = db.listas.Where(item=>item.list==id).LongCount();
                   var dun=db.Scheduleds.Single(item1 => item1.Until == db.Scheduleds.Max(item => item.Until));
                   if (dun.Until > DateTime.Now)
                   {
                       ViewBag.Until = dun.Id;
                   }
                  
                }catch(Exception e){

                }
                    return View(db.listas.Where(item=>item.list==id).ToList());
        }
      
        // GET: listas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lista lista = db.listas.Find(id);
            if (lista == null)
            {
                return HttpNotFound();
            }
            ViewBag.Listuser = lista.list;
            return View(lista);
        }

        // GET: listas/Create
        public ActionResult Create(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.Listuser = id.Value;
            return View();
        }

        // POST: listas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,list,Name,Tel,Cel,Email,Otros")] lista lista)
        {
            if (ModelState.IsValid)
            {
                db.listas.Add(lista);
                db.SaveChanges();
                return RedirectToAction("Index", new {id= lista.list });
            }

            return View(lista);
        }

        // GET: listas/Edit/5
        public ActionResult Edit(int? id,int sched,int type)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lista lista = db.listas.Find(id);
            if (lista == null)
            {
                return HttpNotFound();
            }
            ViewBag.sched = sched;
            ViewBag.Listuser = lista.list;
            ViewBag.type = type;
            return View(lista);
        }

        // POST: listas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,list,Tel,Cel,Email,Otros,Checked")] lista lista, int sched, int type)
        {
            if (ModelState.IsValid)
            {
                if (type == 1&&sched!=0) { 
                db.Scheduleds.Find(sched).Finished = db.Scheduleds.Find(sched).Finished + 1;
                } db.Entry(lista).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index", new {id= lista.list });
            }
            return View(lista);
        }

        // GET: listas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            lista lista = db.listas.Find(id);
            if (lista == null)
            {
                return HttpNotFound();
            }
            ViewBag.Listuser = lista.list;
            return View(lista);
        }

        // POST: listas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            lista lista = db.listas.Find(id);
            db.listas.Remove(lista);
            db.SaveChanges();
            return RedirectToAction("Index", new { id = lista.list });
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
