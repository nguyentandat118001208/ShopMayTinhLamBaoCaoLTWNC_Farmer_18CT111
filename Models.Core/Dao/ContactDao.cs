using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Core.EF;

namespace Models.Core.Dao
{
    public class ContactDao
    {
        ShopMayTinhDbContext db = null;
        public ContactDao()
        {
            db = new ShopMayTinhDbContext();
        }

        public Contact GetActiveContact()
        {
            return db.Contacts.Single(x => x.Status == true);
        }

        public int InsertFeedBack(Feedback fb)
        {
            db.Feedbacks.Add(fb);
            db.SaveChanges();
            return fb.ID;
        }
    }
}