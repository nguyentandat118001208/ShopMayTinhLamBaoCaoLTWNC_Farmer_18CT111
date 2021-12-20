﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Core.EF;

namespace Models.Core.Dao
{
    public class CategoryDao
    {
        ShopMayTinhDbContext db = null;
        public CategoryDao()
        {
            db = new ShopMayTinhDbContext();
        }
        public long Insert(Category category)
        {
            db.Categories.Add(category);
            db.SaveChanges();
            return category.ID;
        }
        public List<Category> ListAll()
        {
            return db.Categories.Where(x => x.Status == true).ToList();
        }
        public ProductCategory ViewDetail(long id)
        {

            return db.ProductCategories.Find(id);
        }
    }
}
