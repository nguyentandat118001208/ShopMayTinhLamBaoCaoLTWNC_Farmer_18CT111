using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Core.EF;
using PagedList.Mvc;
using PagedList;
using Common;
// Day là thuật toán cho usercontroller và LoginController
namespace Models.Core.Dao
{
    public class UserDao
    {
        ShopMayTinhDbContext db = null;
        public UserDao()
        {
            db = new ShopMayTinhDbContext();
        }
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        // THÊM MỘT THÔNG SỐ searchString
        public IEnumerable<User> ListAllPaging(string searchString, int page, int pageSize)
        {
            //search
            IQueryable<User> model = db.Users;
            if (!string.IsNullOrEmpty(searchString))
            { //nếu trong trường hợp khác string(khác rỗng)
                model = model.Where(x => x.UserName.Contains(searchString) || x.Name.Contains(searchString)).OrderByDescending(x => x.CreatedDate); //contains() tìm chuỗi , OrderByDescending(): sắp xếp dần dần
            }
            return model.OrderByDescending(x => x.UserName.Contains(searchString)).ToPagedList(page, pageSize);
            //

            // return db.Users.OrderByDescending(x=>x.CreatedDate).ToPagedList(page, pageSize);
        }

        //phần Update Cho Usercontroller : PHD
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.ID);
                user.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.Password))
                {
                    user.Password = entity.Password;
                }
                user.UserName = entity.UserName;
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.ModifiedBy = entity.ModifiedBy;
                user.ModifiedDate = DateTime.Now;
                user.Status = entity.Status;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }


        }

        public IEnumerable<User> ListAllPaging(int page, int pageSize)
        {
            return db.Users.OrderByDescending(x => x.CreatedDate).ToPagedList(page, pageSize);
        }
        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }
        // Pham Nho Dat
        public User ViewDetail(int id)
        {
            return db.Users.Find(id);
        }
        public List<string> GetListCredential(string userName)
        {
            var user = db.Users.Single(x => x.UserName == userName);
            var data = (from a in db.Credentials
                        join b in db.UserGroups on a.UserGroupID equals b.ID
                        join c in db.Roles on a.RoleID equals c.ID
                        where b.ID == user.GroupID
                        select new
                        {
                            RoleID = a.RoleID,
                            UserGroupID = a.UserGroupID
                        }).AsEnumerable().Select(x => new Credential()
                        {
                            RoleID = x.RoleID,
                            UserGroupID = x.UserGroupID
                        });
            return data.Select(x => x.RoleID).ToList();

        }
        public int Login(string userName, string passWord, bool isLoginAdmin = false)
        {
            var result = db.Users.SingleOrDefault(x => x.UserName == userName);
            if (result == null)
            {
                return 0;
            }
            else
            {
                if (isLoginAdmin == true)
                {
                    if (result.GroupID == CommonConstants.ADMIN_GROUP || result.GroupID == CommonConstants.MOD_GROUP)
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
                    else
                    {
                        return -3;
                    }
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
        //PND : bai 28
        public bool ChangeStatus(long id)
        {
            var user = db.Users.Find(id);
            user.Status = !user.Status;
            db.SaveChanges();
            return user.Status;
        }
        //Phần Delete cho Usercontroller để xóa người dùng: PND
        public bool Delete(int id)
        {
            try
            {
                var user = db.Users.Find(id);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
        public bool CheckUserName(string userName)
        {
            return db.Users.Count(x => x.UserName == userName) > 0;
        }
        public bool CheckEmail(string email)
        {
            return db.Users.Count(x => x.Email == email) > 0;
        }
    }
}