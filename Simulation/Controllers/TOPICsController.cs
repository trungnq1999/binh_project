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
    public class TOPICsController : Controller
    {
        private ITSEntities db = new ITSEntities();

        // GET: TOPICs
        public ActionResult Index()
        {
            return View(db.TOPICs.ToList());
        }

        // GET: TOPICs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOPIC tOPIC = db.TOPICs.Find(id);
            if (tOPIC == null)
            {
                return HttpNotFound();
            }
            return View(tOPIC);
        }

        // GET: TOPICs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TOPICs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TopicID,SubjectID,W_Prerequisite")] TOPIC tOPIC)
        {
            if (ModelState.IsValid)
            {
                db.TOPICs.Add(tOPIC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tOPIC);
        }

        // GET: TOPICs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOPIC tOPIC = db.TOPICs.Find(id);
            if (tOPIC == null)
            {
                return HttpNotFound();
            }
            return View(tOPIC);
        }

        // POST: TOPICs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TopicID,SubjectID,W_Prerequisite")] TOPIC tOPIC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tOPIC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tOPIC);
        }

        // GET: TOPICs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TOPIC tOPIC = db.TOPICs.Find(id);
            if (tOPIC == null)
            {
                return HttpNotFound();
            }
            return View(tOPIC);
        }

        // POST: TOPICs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            TOPIC tOPIC = db.TOPICs.Find(id);
            db.TOPICs.Remove(tOPIC);
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
