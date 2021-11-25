using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Core.EF;

namespace Models.Core.Dao
{

    public class ProductDao
    {
        ShopMayTinhDbContext db = null;
        public ProductDao()
        {
            db = new ShopMayTinhDbContext();
        }
        public List<Product> ListNewProduct(int top)
        {
            return db.Products.OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        public List<Product> ListFeatureProduct(int top)
        {
            return db.Products.Where(x => x.TopHot != null && x.TopHot > DateTime.Now).OrderByDescending(x => x.CreatedDate).Take(top).ToList();
        }
        //H_36
        public List<Product> listByCategoryId(long categoryID, ref int totalRecord, int pageIndex = 1, int pageSize = 2)
        {
            totalRecord = db.Products.Where(x => x.CategoryID == categoryID).Count();
            var model = db.Products.Where(x => x.CategoryID == categoryID).OrderByDescending(x => x.CreatedDate).Skip((pageSize - 1) * pageIndex).Take(pageSize).ToList();
            return model;
        }
        //h_36
        public List<Product> ListRelateProducts(long ProductId)
        {
            var product = db.Products.Find(ProductId);
            return db.Products.Where(x => x.ID != ProductId && x.CategoryID == product.CategoryID).ToList();
        }
        public Product Viewdetail(long id)
        {
            return db.Products.Find(id);
        }
    }
}
