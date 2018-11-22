using System;
using GenericClass.Models;
using GenericClass.Models.Repositories;
using GenericClass.Models.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace GenericClass.Controllers
{
    public class EnrollmentsController : Controller
    {
        private _IGenericRepo<Enrollment> Eobj;

        private ProjectDataEntities _context;

        public EnrollmentsController()
        {
            Eobj = new GenericRepo<Enrollment>();
            _context = new ProjectDataEntities();
        }

        // GET: Enrollments
        public ActionResult Index()
        {
            return View(from e in Eobj.GetAll() select e);
        }

        // GET: Enrollments/Details/5
        public ActionResult Details(int id)
        {
            Enrollment e = Eobj.FindbyID(id);

            return View(e);
        }

        // GET: Enrollments/Create
        public ActionResult Create()
        {

            ViewBag.CourseID = new SelectList(_context.Courses, "CourseID", "Title");
            ViewBag.StudentID = new SelectList(_context.Students, "StudentID", "LastName");
            return View();
        }

        // POST: Enrollments/Create
        [HttpPost]
        public ActionResult Create(Enrollment collection)
        {
            try
            {
                // TODO: Add insert logic here

                Eobj.Insert(collection);
                Eobj.save();
                return RedirectToAction("Index");
            }


            catch
            {
                //ViewBag.CourseID = new SelectList(_context.Courses, "CourseID", "Title", .CourseID);
                //ViewBag.StudentID = new SelectList(_context.Students, "StudentID", "LastName", enrollment.StudentID);
                return View();
            }
        }

        // GET: Enrollments/Edit/5
        public ActionResult Edit(int id)
        {

            Enrollment e = Eobj.FindbyID(id);

            ViewBag.CourseID = new SelectList(_context.Courses, "CourseID", "Title", e.CourseID);
            ViewBag.StudentID = new SelectList(_context.Students, "StudentID", "LastName", e.StudentID);
            return View(e);
        
            
        }

        // POST: Enrollments/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Enrollment collection)
        {
            try
            {
                Eobj.UpdateByID(collection);
                Eobj.save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Enrollments/Delete/5
        public ActionResult Delete(int id)
        {
            Enrollment e = Eobj.FindbyID(id);

            ViewBag.CourseID = new SelectList(_context.Courses, "CourseID", "Title", e.CourseID);
            ViewBag.StudentID = new SelectList(_context.Students, "StudentID", "LastName", e.StudentID);
            return View(e);
        }

        // POST: Enrollments/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Enrollment collection)
        {
            try
            {
                
                Eobj.Remove(id);
                Eobj.save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
