using LibraryManagementSystem_A2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryManagementSystem_A2.Controllers
{
    [RequireHttps]
    [Route("home/{action=index}")]
    public class HomeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [Route("")]
        [Route("home")]
        [Route("home/index")]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult BookSearch(string q)
        {
            var books = GetBook(q);
            return PartialView(books);
        }

        public ActionResult QuickSearch(string term)
        {
            var cars = GetBook(term).Select(a => new { value = a.Title });
            return Json(cars, JsonRequestBehavior.AllowGet);
        }

        private List<Book> GetBook(string searchString)
        {
            return db.Books.Where(a => a.Title.Contains(searchString)).ToList();
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