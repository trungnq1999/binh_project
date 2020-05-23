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
    public class CONCEPTsController : Controller
    {
        private ITSEntities db = new ITSEntities();

        // GET: CONCEPTs
        public ActionResult Index()
        {
            var cONCEPTs = db.CONCEPTs.Include(c => c.TOPIC);
            return View(cONCEPTs.ToList());
        }

        // GET: CONCEPTs/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONCEPT cONCEPT = db.CONCEPTs.Find(id);
            if (cONCEPT == null)
            {
                return HttpNotFound();
            }
            return View(cONCEPT);
        }

        // GET: CONCEPTs/Create
        public ActionResult Create()
        {
            ViewBag.TopicID = new SelectList(db.TOPICs, "TopicID", "SubjectID");
            return View();
        }

        // POST: CONCEPTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ConceptID,TopicID,Concept_Name,Concept_Content,Concept_Weight")] CONCEPT cONCEPT)
        {
            if (ModelState.IsValid)
            {
                db.CONCEPTs.Add(cONCEPT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TopicID = new SelectList(db.TOPICs, "TopicID", "SubjectID", cONCEPT.TopicID);
            return View(cONCEPT);
        }

        // GET: CONCEPTs/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONCEPT cONCEPT = db.CONCEPTs.Find(id);
            if (cONCEPT == null)
            {
                return HttpNotFound();
            }
            ViewBag.TopicID = new SelectList(db.TOPICs, "TopicID", "SubjectID", cONCEPT.TopicID);
            return View(cONCEPT);
        }

        // POST: CONCEPTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConceptID,TopicID,Concept_Name,Concept_Content,Concept_Weight")] CONCEPT cONCEPT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cONCEPT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TopicID = new SelectList(db.TOPICs, "TopicID", "SubjectID", cONCEPT.TopicID);
            return View(cONCEPT);
        }

        // GET: CONCEPTs/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CONCEPT cONCEPT = db.CONCEPTs.Find(id);
            if (cONCEPT == null)
            {
                return HttpNotFound();
            }
            return View(cONCEPT);
        }

        // POST: CONCEPTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            CONCEPT cONCEPT = db.CONCEPTs.Find(id);
            db.CONCEPTs.Remove(cONCEPT);
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
