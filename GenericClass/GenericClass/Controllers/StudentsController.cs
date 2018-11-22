using GenericClass.Models;
using GenericClass.Models.Interfaces;
using GenericClass.Models.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GenericClass.Controllers
{
    public class StudentsController : Controller
    {
        private _IGenericRepo<Student> Sobj;                 //declare the object of interface of _IGenericRepo


        public StudentsController()                        //Constructor to initiate the object of interface with GenericRepo Class to implement its methods.
        {

            Sobj = new GenericRepo<Student>();

        }

        // GET: Students
        public ActionResult Index()
        {
           
           return View(from s in Sobj.GetAll() select s);   //lamba expression in the method to retrive all the data from database using lamba expression
        }

        // GET: Students/Details/5
        public ActionResult Details(int id)
        {
            Student s = Sobj.FindbyID(id);                 // Get detail of the specific id passing as a parameter to object of GenericRepo class 
            return View(s);
        }

        // GET: Students/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Students/Create
        [HttpPost]
        public ActionResult Create(Student collection)                     // Create method to add something in the student table in the database
        {
            try
            {
                // TODO: Add insert logic here
                Sobj.Insert(collection);
                Sobj.save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Edit/5
        public ActionResult Edit(int id)                       //Edit method to get the detail of the data with specific id 
        {
            Student s = Sobj.FindbyID(id);                    //with the studentclass object s get the detail and pass it to view(s);
            return View(s);
        }                                                    //so that we can see the detailt of the row and edit it.

        // POST: Students/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, Student collection)             //Edit method to update in the student table.
        {
            try
            {
                // TODO: Add update logic here
                Sobj.UpdateByID(collection);
                Sobj.save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Students/Delete/5                                       //delete method to get the detail of the data with specific id 
        public ActionResult Delete(int id)                             
        {
            Student s = Sobj.FindbyID(id);

            return View(s);
        }

        // POST: Students/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Student collection)         //delete method to get the detail of the data with specific id 
        {
            try
            {
                // TODO: Add delete logic here
                Sobj.Remove(id);
                Sobj.save();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
