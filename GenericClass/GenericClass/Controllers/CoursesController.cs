using GenericClass.Models;
using GenericClass.Models.Repositories;
using GenericClass.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenericClass.Controllers
{
    public class CoursesController : Controller
    {
        private _IGenericRepo<Course> Cobj;                         //declare the object of interface of _IGenericRepo

        public CoursesController()                          //Constructor to initiate the object of interface with GenericRepo Class to implement its methods.
        {

            Cobj = new GenericRepo<Course>();

        }

        // GET: Course
        public ActionResult Index()
        {
            return View(from c in Cobj.GetAll() select c);      //lamba expression in the method to retrive all the data from database using lamba expression
        }

        // GET: Course/Details/5
        public ActionResult Details(int id)                     // Get detail of the specific id passing as a parameter to object of GenericRepo class 
        {
            Course c = Cobj.FindbyID(id);

            return View(c);
        }

        // GET: Course/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Course/Create
        [HttpPost]
        public ActionResult Create(Course collection)                     // Create method to add something in the student table in the database
        {
            try
            {
                Cobj.Insert(collection);
                Cobj.save();

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Edit/5
        public ActionResult Edit(int id)                             //Edit method to get the detail of the data with specific id 
        {
            Course c = Cobj.FindbyID(id);                            //with the Courseclass object s get the detail and pass it to view(s);
            return View(c);                                          //so that we can see the detailt of the row and edit it.            
        }

        // POST: Course/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Course collection)                //Edit method to update in the student table.
        {
            try
            {
                Cobj.UpdateByID(collection);
                Cobj.save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Course/Delete/5
        public ActionResult Delete(int id)                                   //delete method to get the detail of the data with specific id 
        {
            Course c = Cobj.FindbyID(id);
            return View(c);
        }

        // POST: Course/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Course collection)                        //delete method to get the detail of the data with specific id
        {
            try
            {
                Cobj.Remove(id);
                Cobj.save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
