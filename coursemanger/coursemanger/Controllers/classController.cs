using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using coursemanger.Models;

namespace coursemanger.Controllers
{
    public class classController : Controller
    {
        private coursemangerEntities db = new coursemangerEntities();

        //
        // GET: /class/

        public ActionResult Index()
        {
            return View(db.classes.ToList());
        }

        //
        // GET: /class/Details/5

        public ActionResult Details(int id = 0)
        {
            classes classes = db.classes.Find(id);
            if (classes == null)
            {
                return HttpNotFound();
            }
            return View(classes);
        }

        //
        // GET: /class/Create

        public ActionResult Create()

        {
            var teachers = db.teachers.ToList();
            ViewBag.teachers = teachers;

            return View();
        }

        //
        // POST: /class/Create

        [HttpPost]
        public ActionResult Create(classes classes)
        {
            if (ModelState.IsValid)
            {
                db.classes.Add(classes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(classes);
        }

        //
        // GET: /class/Edit/5

        public ActionResult Edit(int id = 0)
        {
            var teachers = db.teachers.ToList();
            ViewBag.teachers = teachers;
            classes classes = db.classes.Find(id);
            if (classes == null)
            {
                return HttpNotFound();
             
            }
            return View(classes);
        }

        //
        // POST: /class/Edit/5

        [HttpPost]
        public ActionResult Edit(classes classes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(classes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(classes);
        }

        //
        // GET: /class/Delete/5

        public ActionResult Delete(int id = 0)
        {
            classes classes = db.classes.Find(id);
            if (classes == null)
            {
                return HttpNotFound();
            }
            return View(classes);
        }

        //
        // POST: /class/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            classes classes = db.classes.Find(id);
            db.classes.Remove(classes);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}