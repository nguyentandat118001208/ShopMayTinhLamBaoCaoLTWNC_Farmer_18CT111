using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Core.EF;

namespace Models.Core.Dao
{
    public class FooterDao
    {
        ShopMayTinhDbContext db = null;
        public FooterDao()
        {
            db = new ShopMayTinhDbContext();
        }
        public Footer GetFooter()
        {
            return db.Footers.SingleOrDefault(x => x.Status == true);
        }
    }
}
