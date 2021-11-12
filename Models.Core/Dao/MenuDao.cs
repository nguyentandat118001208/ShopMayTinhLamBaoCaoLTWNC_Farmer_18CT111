using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Core.EF;
//31 HDDH
namespace Models.Core.Dao
{
    public class MenuDao
    {
        ShopMayTinhDbContext db = null;
        public MenuDao()
        {
            db = new ShopMayTinhDbContext();
        }
        public List<Menu> ListByGroupId(int groupId)
        {
            return db.Menus.Where(x => x.TypeID == groupId && x.Status == true).OrderBy(x => x.DisplayOrder).ToList();
        }
    }
}
