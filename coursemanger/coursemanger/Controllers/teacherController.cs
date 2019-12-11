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
    public class teacherController : Controller
    {
        private coursemangerEntities db = new coursemangerEntities();

        //
        // GET: /teacher/

        public ActionResult Index()
        {
            return View(db.teachers.ToList());
        }

        //
        // GET: /teacher/Details/5

        public ActionResult Details(int id = 0)
        {
            teachers teachers = db.teachers.Find(id);
            if (teachers == null)
            {
                return HttpNotFound();
            }
            return View(teachers);
        }

        //
        // GET: /teacher/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /teacher/Create

        [HttpPost]
        public ActionResult Create(teachers teachers)
        {
            if (ModelState.IsValid)
            {
                db.teachers.Add(teachers);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(teachers);
        }

        //
        // GET: /teacher/Edit/5

        public ActionResult Edit(int id = 0)
        {
            teachers teachers = db.teachers.Find(id);
            if (teachers == null)
            {
                return HttpNotFound();
            }
            return View(teachers);
        }

        //
        // POST: /teacher/Edit/5

        [HttpPost]
        public ActionResult Edit(teachers teachers)
        {
            if (ModelState.IsValid)
            {
                db.Entry(teachers).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(teachers);
        }

        //
        // GET: /teacher/Delete/5

        public ActionResult Delete(int id = 0)
        {
            teachers teachers = db.teachers.Find(id);
            if (teachers == null)
            {
                return HttpNotFound();
            }
            return View(teachers);
        }

        //
        // POST: /teacher/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            teachers teachers = db.teachers.Find(id);
            db.teachers.Remove(teachers);
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