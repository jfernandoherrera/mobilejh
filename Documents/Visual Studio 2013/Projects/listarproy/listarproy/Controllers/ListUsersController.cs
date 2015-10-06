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
    public class ListUsersController : Controller
    {
        private listarproyContext db = new listarproyContext();

        // GET: ListUsers
        public ActionResult Index()
        {
            ViewBag.listLength = db.ListUsers.Where(item => item.IdUser == User.Identity.Name).LongCount();
            return View(db.ListUsers.Where(item=>item.IdUser==User.Identity.Name).ToList());
        }

        // GET: ListUsers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ViewBag.id = id;
            ListUser listUser = db.ListUsers.Find(id);
            if (listUser == null)
            {
                return HttpNotFound();
            }
            return View(db.ListUsers.Where(item => item.IdUser == User.Identity.Name).ToList());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Details(int? id,int idfrom)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            IQueryable<lista> copy = db.listas.Where(item => item.list == idfrom);
          //  int idfinal = db.listas.Max(item => item.Id);
           foreach (lista item in copy)
            {
            //    idfinal++;
              //  item.Id = idfinal;
                item.list = id.Value;
            }
            db.listas.AddRange(copy);
            db.SaveChanges();
            return RedirectToAction("Index");
            

        }
        // GET: ListUsers/Create
        public ActionResult Create(int? id)
        {
            
            return View(id);
        }

        // POST: ListUsers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,IdUser")] ListUser listUser)
        {
            if (ModelState.IsValid)
            {   
                db.ListUsers.Add(listUser);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(listUser);
        }/*
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CreateCopy([Bind(Include = "Id,Name,IdUser")] ListUser listUser)
        {
            if (ModelState.IsValid)
            {
                db.ListUsers.Add(listUser);
                IQueryable<lista> copy = db.listas.Where(item => item.list == listUser.Id);
                int idfinal = db.listas.Max(item => item.Id);
                foreach(lista item in  copy){
                 idfinal++;
                 item.Id = idfinal;
                }
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(listUser);
        }
        */
        // GET: ListUsers/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListUser listUser = db.ListUsers.Find(id);
            if (listUser == null)
            {
                return HttpNotFound();
            }
            return View(listUser);
        }

        // POST: ListUsers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,IdUser")] ListUser listUser)
        {
            if (ModelState.IsValid)
            {
                db.Entry(listUser).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(listUser);
        }

        // GET: ListUsers/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ListUser listUser = db.ListUsers.Find(id);
            if (listUser == null)
            {
                return HttpNotFound();
            }
            return View(listUser);
        }

        // POST: ListUsers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ListUser listUser = db.ListUsers.Find(id);
            db.ListUsers.Remove(listUser);
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
