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
    public class studentController : Controller
    {
        private coursemangerEntities db = new coursemangerEntities();

        //
        // GET: /student/

        public ActionResult Index()
        {
            return View(db.students.ToList());
        }

        //
        // GET: /student/Details/5

        public ActionResult Details(int id = 0)
        {
            students students = db.students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        //
        // GET: /student/Create

        public ActionResult Create()
        {
            var classid =db.classes.ToList();
            ViewBag.classid=classid;

            return View();
        }

        //
        // POST: /student/Create

        [HttpPost]
        public ActionResult Create(students students)
        {
            if (ModelState.IsValid)
            {
                db.students.Add(students);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(students);
        }

        //
        // GET: /student/Edit/5

        public ActionResult Edit(int id = 0)
        {
            students students = db.students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        //
        // POST: /student/Edit/5

        [HttpPost]
        public ActionResult Edit(students students)
        {
            if (ModelState.IsValid)
            {
                db.Entry(students).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(students);
        }

        //
        // GET: /student/Delete/5

        public ActionResult Delete(int id = 0)
        {
            students students = db.students.Find(id);
            if (students == null)
            {
                return HttpNotFound();
            }
            return View(students);
        }

        //
        // POST: /student/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            students students = db.students.Find(id);
            db.students.Remove(students);
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