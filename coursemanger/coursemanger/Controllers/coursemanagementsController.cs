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
    public class coursemanagementsController : Controller
    {
        private coursemangerEntities db = new coursemangerEntities();

        //
        // GET: /coursemanagements/

        public ActionResult Index()
        {
            return View(db.coursemanagements.ToList());
        }

        //
        // GET: /coursemanagements/Details/5

        public ActionResult Details(int id = 0)
        {
            coursemanagements coursemanagements = db.coursemanagements.Find(id);
            if (coursemanagements == null)
            {
                return HttpNotFound();
            }
            return View(coursemanagements);
        }

        //
        // GET: /coursemanagements/Create

        public ActionResult Create()

        {

            var classes = db.classes.ToList();
            ViewBag.classes = classes;

            var teachers = db.teachers.ToList();
            ViewBag.teachers = teachers;


            var course = db.course.ToList();
            ViewBag.course = course;



            return View();
        }

        //
        // POST: /coursemanagements/Create

      [HttpPost]
        public ActionResult Create(coursemanagements coursemanagements)
        {
            if (ModelState.IsValid)
            {
                db.coursemanagements.Add(coursemanagements);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(coursemanagements);
        }

        //
        // GET: /coursemanagements/Edit/5

        public ActionResult Edit(int id = 0)
        {
            coursemanagements coursemanagements = db.coursemanagements.Find(id);
            if (coursemanagements == null)
            {
                return HttpNotFound();
            }
            return View(coursemanagements);
        }

        //
        // POST: /coursemanagements/Edit/5

        [HttpPost]
        public ActionResult Edit(coursemanagements coursemanagements)
        {
            if (ModelState.IsValid)
            {
                db.Entry(coursemanagements).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(coursemanagements);
        }

        //
        // GET: /coursemanagements/Delete/5

        public ActionResult Delete(int id = 0)
        {
            coursemanagements coursemanagements = db.coursemanagements.Find(id);
            if (coursemanagements == null)
            {
                return HttpNotFound();
            }
            return View(coursemanagements);
        }

        //
        // POST: /coursemanagements/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            coursemanagements coursemanagements = db.coursemanagements.Find(id);
            db.coursemanagements.Remove(coursemanagements);
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