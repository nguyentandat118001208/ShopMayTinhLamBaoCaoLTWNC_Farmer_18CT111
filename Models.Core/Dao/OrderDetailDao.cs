using Models.Core.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Core.Dao
{
    public class OrderDetailDao
    {
        ShopMayTinhDbContext db = null;
        public OrderDetailDao()
        {
            db = new ShopMayTinhDbContext();
        }
        public bool Insert(OrderDetail detail)
        {
            try
            {
                db.OrderDetails.Add(detail);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;

            }
        }
    }
}
