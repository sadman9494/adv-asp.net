using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zerohunger.Models;

namespace zerohunger.Controllers
{
    public class restController : Controller
    {
        // GET: collect
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult create()
        {

            return View();

        }
        [HttpPost]
        public ActionResult create(collectreq c)
        {
            NGOEntities6 db = new NGOEntities6();
            db.collectreqs.Add(c);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}