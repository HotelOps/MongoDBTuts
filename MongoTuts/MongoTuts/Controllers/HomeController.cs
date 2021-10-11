using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MongoTuts.DBController;

namespace MongoTuts.Controllers
{
    public class HomeController : Controller
    {
        MongoDBController objM = new MongoDBController();
        public ActionResult Index()
        {

            var DbList = objM.DBList();
            TempData["DbList"] = DbList;
            return View();
        }
        [HttpPost]
        public ActionResult Index(string Name, string City, string Remarks)
        {
            var document = new MongoDB.Bson.BsonDocument();
            document.Add(new MongoDB.Bson.BsonElement("Name", Name));
            document.Add(new MongoDB.Bson.BsonElement("City", City));
            document.Add(new MongoDB.Bson.BsonElement("Remarks", Remarks));
            document.Add(new MongoDB.Bson.BsonElement("timestamp", DateTime.Now.Ticks));






            objM.Insert(document, "test");



            return View();
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}