using Model.Dao;
using Model.EF;
using AuctionOnline.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.DynamicData;
using System.Web.Mvc;
using PagedList;

namespace AuctionOnline.Areas.admin.Controllers
{
    public class UsersController : Controller
    {
        // GET: admin/Users
        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var dao = new UsersDao();

            var model = dao.ListAllPaging(page, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        public ActionResult Edit(int id)
        {
            var user = new UsersDao().ViewDetail(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UsersDao();
                //var encryptedMd5Pas = Encryptor.MD5Hash(user.Password);
                //user.Password = encryptedMd5Pas;
                long id = dao.Insert(user);
                if (id > 0)
                {
                    return RedirectToAction("Index", "Users");
                }
            }
            else
            {
                ModelState.AddModelError("", "Add user fail");
            }
            return View("Index");
        }

        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var dao = new UsersDao();
                //var encryptedMd5Pas = Encryptor.MD5Hash(user.Password);
                //user.Password = encryptedMd5Pas;
                var result = dao.Update(user);
                if (result)
                {
                    return RedirectToAction("Index", "Users");
                }
            }
            else
            {
                ModelState.AddModelError("", "Edit information fail");
            }
            return View("Index");
        }

        public ActionResult Delete(int id)
        {
            new UsersDao().Delete(id);
            return RedirectToAction("Index");
        }
    }
}
