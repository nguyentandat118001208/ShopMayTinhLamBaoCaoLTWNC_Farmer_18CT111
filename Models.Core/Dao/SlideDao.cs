using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Core.EF;
// 32 quang
namespace Models.Core.Dao
{
    public class SlideDao
    {
        ShopMayTinhDbContext db = null;
        public SlideDao()
        {
            db = new ShopMayTinhDbContext();
        }
        public List<Slide> ListAll()
        {
            return db.Slides.Where(x => x.Status == true).OrderBy(y => y.DisplayOrder).ToList();
        }
    }
}
