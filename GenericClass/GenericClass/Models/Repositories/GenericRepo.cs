using GenericClass.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GenericClass.Models.Repositories
{
    public class GenericRepo<T> : _IGenericRepo<T> where T : class   // GenericClass<T> inheritated by InterFace _IGenericRepo
    {
        private ProjectDataEntities _context;         // Declaring the database projectdataentities object _context

        private IDbSet<T> dbentity;                    //An IDbSet<TEntity> represents the collection of all entities in the context, or that can be queried from the database, of a given type. DbSet<TEntity> is a concrete implementation of IDbSet.

        public GenericRepo()                            //Constructor of GenericRepo class to initiate the dbentity object of IDbset<T>, so that we use the methods of IDbSet<T> class with the object
        {
            _context = new ProjectDataEntities();
            dbentity = _context.Set<T>();

        }

       
        public T FindbyID(int modelID)               //FindBy method is used to find data in the database with specific ID.
        {

           return dbentity.Find(modelID);           //dbentity.Find(modelID) Find is the generic method of class Idbset.

        }

        public IEnumerable<T> GetAll()                  //To get all the data from database
        {
            return dbentity.ToList();
        }

        public void Insert(T model)                          //Insert or create something in the database.
        {
            dbentity.Add(model);
        }

        public void Remove(int modelID)                     //to delete something in the database with the specific ID
        {
          T model  = dbentity.Find(modelID);              // First find the id of the data then delete it with specific id.
            dbentity.Remove(model);
        }

        public void save()                                    //after everyhing save changes in the database.
        {
            _context.SaveChanges();
        }

        public void UpdateByID(T model)                           //to update something in the database.
        {
            _context.Entry(model).State = System.Data.Entity.EntityState.Modified;       
        }
    }

}