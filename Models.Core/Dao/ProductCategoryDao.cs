using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Core.EF;
//32 quang
namespace Models.Core.Dao
{
    public class ProductCategoryDao
    {
        ShopMayTinhDbContext db = null;
        public ProductCategoryDao()
        {
            db = new ShopMayTinhDbContext();
        }
        public List<ProductCategory> ListAll()
        {
            return db.ProductCategories.Where(x => x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }
    }
}
