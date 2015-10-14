using Hermes.Data.Models;
using System;
using System.Data.Entity;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Hermes.Web.Controllers
{
    public class TestController : Controller
    {
        HermesContext db = new HermesContext();
        //
        // GET: /Test/
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public void stuff()
        {
            DateTime date = Convert.ToDateTime("2/19/2014");
            var regulars = db.Regulars.Where(x=>x.Date == date).ToList();
            int count = 0;
            foreach (var item in regulars) {

                count = count + item.Members.Count();
            }

            
        }
	}
}