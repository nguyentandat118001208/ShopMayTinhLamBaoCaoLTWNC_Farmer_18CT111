using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Core.EF;

namespace Models.Core.Dao
{
    public class UserDao
    {
        ShopMayTinhDbContext db = null;
        public UserDao()
        {
            db = new ShopMayTinhDbContext();
        }
        public IEnumerable<User> ListAllPaging(int page, int pageSize) //trả về tất cả danh sách user
        {
            return db.Users.ToPagedList(page, pageSize);
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }
        public int Login(string userName, string passWord)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (result.Status == false)
                {
                    return -1;
                }
                else
                {
                    if (result.Password == passWord)
                        return 1;
                    else
                        return -2;


                }
            }
        }
    }
}