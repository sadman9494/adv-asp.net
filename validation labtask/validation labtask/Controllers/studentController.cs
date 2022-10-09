using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using validation_labtask.Models;


namespace validation_labtask.Controllers
{
    public class studentController : Controller
    {
        // GET: student
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult details()
        {
            
            return View();
        }

        [HttpPost]
        public ActionResult details(student std)
        
        {
            
           return View();
        }
    }
}