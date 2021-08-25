﻿using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface ICategoryService
    {
        List<Category> GetCatList();
        void AddCategory(Category category);
        Category GetById(int id);

        void CategoryDelete(Category category);
        void CategoryUpdate(Category category);
       
    }

}