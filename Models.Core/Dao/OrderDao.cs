using Models.Core.EF;
using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Core.Dao
{
    public class OrderDao
    {
        ShopMayTinhDbContext db = null;
        public OrderDao()
        {
            db = new ShopMayTinhDbContext();
        }
        public long Insert(Order order)
        {
            db.Orders.Add(order);
            db.SaveChanges();
            return order.ID;
        }      
    }
}
