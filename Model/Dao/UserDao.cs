using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model.EF;
using PagedList;
using PagedList.Mvc;
namespace Model.Dao
{
    public class UsersDao
    {
        AuctionOnlineDbContext db = null;

        public UsersDao()
        {
            db = new AuctionOnlineDbContext();
        }

        //Function Insert
        public long Insert(User entity)
        {
            db.Users.Add(entity);
            db.SaveChanges();
            return entity.UserID;
        }

        //Function Update
        public bool Update(User entity)
        {
            try
            {
                var user = db.Users.Find(entity.UserID);
                user.Name = entity.Name;
                user.Password = entity.Password;
                user.Address = entity.Address;
                user.Email = entity.Email;
                user.Phone = entity.Phone;
                user.ModifiedDate = DateTime.Now;
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }

        }

        public IEnumerable<User> ListAllPaging(int page, int pageSize)
        {
            return db.Users.OrderByDescending(x => x.CreateDate).ToPagedList(page, pageSize); 
        } 
        //ViewDetail
        public User ViewDetail(int UserID)
        {
            return db.Users.Find(UserID);
        }

        public User GetById(string userName)
        {
            return db.Users.SingleOrDefault(x => x.UserName == userName);
        }

        public int Login(string userName, string Password)
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
                    if (result.Password == Password)
                    {
                        return 1;
                    }
                    else
                    {
                        return -2;
                    }
                }
            }
        }

        public bool Delete(int UserID)
        {
            try
            {
                var user = db.Users.Find(UserID);
                db.Users.Remove(user);
                db.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}