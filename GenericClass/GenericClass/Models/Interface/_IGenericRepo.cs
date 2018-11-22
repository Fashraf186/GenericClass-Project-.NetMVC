﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericClass.Models.Interface
{
    interface _IGenericRepo<T> where T : class
    {
        IEnumerable<T> GetAll();

        T FindbyID(int modelID);

        void Insert(T model);

        void UpdateByID(T model);


        void Remove(int model);

        void save();




    }
}
