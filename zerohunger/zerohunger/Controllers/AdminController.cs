using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using zerohunger.Models;

namespace zerohunger.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult show()
        {
            NGOEntities6 db = new NGOEntities6();
            var data = db.collectreqs.ToList();
            return View(data);
        }
        public ActionResult Assign(int id, String loc)
        {
           
            NGOEntities6 db = new NGOEntities6();
            var data = (from col in db.collectreqs
                        where col.collectid == id
                        select col).FirstOrDefault();
            //var em = (from emp in db.emps
            //           where emp.location == loc
            //           select emp);
            //ViewBag.em = new SelectList(em,"id", "name");
            return View(data);
        }
        [HttpPost]
        public ActionResult Assign(collectreq c)
        {
            NGOEntities6 db = new NGOEntities6();
            var data = (from col in db.collectreqs
                        where col.collectid == c.collectid
                        select col).FirstOrDefault();
            db.Entry(data).CurrentValues.SetValues(c);
            db.SaveChanges();
            return RedirectToAction("show");
        }

        public ActionResult Createmp()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Createmp(emp e)
        {
            NGOEntities6 db = new NGOEntities6();
            db.emps.Add(e);
            db.SaveChanges();
            return RedirectToAction("showemp");
        }
        public ActionResult showemp()
        {
            NGOEntities6 db = new NGOEntities6();
            var data = db.emps.ToList();
            return View(data);
        }

        public ActionResult delete(int id)
        {
            NGOEntities6 db = new NGOEntities6();
            var data = (from e in db.emps
                        where e.id == id
                        select e).FirstOrDefault();
            
            return View(data);
        }

        [HttpPost]
        public ActionResult delete(emp employee)
        {
            NGOEntities6 db = new NGOEntities6();
            var data = (from e in db.emps
                        where e.id == employee.id 
                        select e).FirstOrDefault();

            var d = (from e in db.collectreqs
                     where e.empid == employee.id
                     select e).FirstOrDefault();

            if (data.id == d.empid)
            {
                d.empid = null;
                
                db.emps.Remove(data);
                db.SaveChanges();
            }
            else
            {
                db.emps.Remove(data);
                db.SaveChanges();
            }
            
            return RedirectToAction("showemp");
        }

        public ActionResult delreq(int id )
        {
            NGOEntities6 db = new NGOEntities6();
            var data = (from e in db.collectreqs
                        where e.collectid == id
                        select e).FirstOrDefault();

            return View(data);
        }

        [HttpPost]
        public ActionResult delreq (collectreq c)
        {
            NGOEntities6 db = new NGOEntities6();

            db.collectreqs.Remove(c);
            db.SaveChanges();

            return RedirectToAction("show");
        }
       

    }
}