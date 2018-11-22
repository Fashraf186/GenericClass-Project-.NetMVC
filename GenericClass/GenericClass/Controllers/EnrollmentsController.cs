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

        private ProjectDataEntities _context;  //declare the object of the database to get access the members of Course and Student table.

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
        public ActionResult Create()  //This create method is used to get data from database for the temporary purpose because of the dropdownlist in the view/create file.
        {

            ViewBag.CourseID = new SelectList(_context.Courses, "CourseID", "Title");  //retriving data from Course table. 
            ViewBag.StudentID = new SelectList(_context.Students, "StudentID", "LastName"); //retriving data from student table.
            return View();  //Viewbag.CourseId/StudentID is used for temporary data holding.
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
