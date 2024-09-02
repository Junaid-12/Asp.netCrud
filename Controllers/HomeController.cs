using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XoDataWeb.Models;


namespace CrudinAspnet.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
              
            DBContext db = new DBContext();
          
            return View(db.GelAllData().ToList());

        }

        
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(DataMo md)
            
        {
            try
            {
                DBContext db = new DBContext();
                db.AddData(md);
                return RedirectToAction("Index");
            }
            catch( Exception ex)
            {
                return View("Index");
            }
            

        }
        [HttpGet]
        public ActionResult Update(int id)
        {
            DBContext db = new DBContext();
            return View(db.GelAllData().Find(x => x.ID == id));
        }
        [HttpPost]
        public ActionResult Update(DataMo md)

        {
            try
            {
                DBContext db = new DBContext();
                db.Updatedata(md);
                return RedirectToAction("index");
            }
            catch (Exception)
            {
                return View("Index");
            }

        }
        public ActionResult Delete(int id)

        {
            try
            {
                DBContext db = new DBContext();
                db.DeleteData(id);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return View();
            }

        }
        public ActionResult Details(int id)
        {
            try
            {

                DBContext db = new DBContext();
                return View(db.GelAllData().Find(x => x.ID == id));
               
            }
            catch(Exception ex)
            {
                return View();

            }
        }

    }
}