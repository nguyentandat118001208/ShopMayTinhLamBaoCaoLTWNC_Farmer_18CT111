using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models.Core.EF;
using PagedList;

namespace Models.Core.Dao
{
    public class ContentDao
    {
        ShopMayTinhDbContext db = null;
        public ContentDao()
        {
            db = new ShopMayTinhDbContext();
        }
        public Content_ GetByID(long id)
        {
            //return db.Content_.Find(id);
            return db.Content_.SingleOrDefault(x => x.CategoryID == id);
        }
        public long Insert(Content_ entity)
        {
            db.Content_.Add(entity);
            db.SaveChanges();
            return entity.ID;
        }
        public bool Update(Content_ entity)
        {
            try
            {
                var content = db.Content_.Find(entity.ID);
                content.Name = entity.Name;
                if (!string.IsNullOrEmpty(entity.MetaDescriptions))
                {
                    content.MetaDescriptions = entity.MetaDescriptions;
                }
                content.Name = entity.Name;
                content.MetaTitle = entity.MetaTitle;
                content.Description = entity.Description;
                content.Image = entity.Image;
                content.ModifiedBy = entity.ModifiedBy;
                content.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                //logging
                return false;
            }
        }
        // THÊM MỘT THÔNG SỐ searchString
        public IEnumerable<Content_> ListAllPagingContent(string searchString, int page, int pageSize)
        {
            //search
            IQueryable<Content_> model = db.Content_;
            if (!string.IsNullOrEmpty(searchString))
            { //nếu trong trường hợp khác string(khác rỗng)
                model = model.Where(x => x.Name.Contains(searchString) || x.Name.Contains(searchString)).OrderByDescending(x => x.CreatedDate); //contains() tìm chuỗi , OrderByDescending(): sắp xếp dần dần

            }
            return model.OrderByDescending(x => x.Name.Contains(searchString)).ToPagedList(page, pageSize);
            //

            // return db.Users.OrderByDescending(x=>x.CreatedDate).ToPagedList(page, pageSize);
        }
        public Content_ ViewDetail(long id)
        {
            return db.Content_.Find(id);
        }
        public bool Delete(int id)
        {
            try
            {
                var content = db.Content_.Find(id);
                db.Content_.Remove(content);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
