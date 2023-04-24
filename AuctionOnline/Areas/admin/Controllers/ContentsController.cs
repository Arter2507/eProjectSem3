using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.EF;

namespace AuctionOnline.Areas.admin.Controllers
{
    public class ContentsController : Controller
    {
        private AuctionOnlineDbContext db = new AuctionOnlineDbContext();

        // GET: admin/Contents
        public ActionResult Index()
        {
            return View(db.Contents.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }
    }
}
