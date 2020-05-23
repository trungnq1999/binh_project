using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Simulation.Models;

namespace Simulation.Controllers
{
    public class SUBJECTsController : Controller
    {
        private ITSEntities db = new ITSEntities();

        // GET: SUBJECTs
        public ActionResult Index()
        {
            return View(db.SUBJECTs.ToList());
        }

        // GET: SUBJECTs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUBJECT sUBJECT = db.SUBJECTs.Find(id);
            if (sUBJECT == null)
            {
                return HttpNotFound();
            }
            return View(sUBJECT);
        }

        // GET: SUBJECTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SUBJECTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SubjectID,SubjectName")] SUBJECT sUBJECT)
        {
            if (ModelState.IsValid)
            {
                db.SUBJECTs.Add(sUBJECT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(sUBJECT);
        }

        // GET: SUBJECTs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUBJECT sUBJECT = db.SUBJECTs.Find(id);
            if (sUBJECT == null)
            {
                return HttpNotFound();
            }
            return View(sUBJECT);
        }

        // POST: SUBJECTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SubjectID,SubjectName")] SUBJECT sUBJECT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sUBJECT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(sUBJECT);
        }

        // GET: SUBJECTs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SUBJECT sUBJECT = db.SUBJECTs.Find(id);
            if (sUBJECT == null)
            {
                return HttpNotFound();
            }
            return View(sUBJECT);
        }

        // POST: SUBJECTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            SUBJECT sUBJECT = db.SUBJECTs.Find(id);
            db.SUBJECTs.Remove(sUBJECT);
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
