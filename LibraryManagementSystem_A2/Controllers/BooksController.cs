using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using LibraryManagementSystem_A2.Models;

namespace LibraryManagementSystem_A2.Controllers
{
    
    [RequireHttps]
    public class BooksController : Controller
    {

        IBookDAL DAL;
        public BooksController(IBookDAL DAL)
        {
            this.DAL = DAL;
        }

        [Route("books/list")]
        // GET: Books
        public ActionResult Index()
        {
            var books = DAL.GetAllBooks();
            return View(books.ToList());
        }

        [Route("books/details/{id:int=1}")]
        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = DAL.FindById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [Authorize(Roles = "Admin")]
        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "BookId,Isbn,Title,Year,Author,ImageUrl")] Book book)
        {
            if (ModelState.IsValid)
            {
                DAL.SaveNewBook(book);
                return RedirectToAction("Index");
            }

            return View(book);
        }

        [Authorize(Roles = "Admin")]
        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = DAL.FindById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [Authorize(Roles = "Admin")]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "BookId,Isbn,Title,Year,Author,ImageUrl")] Book book)
        {
            if (ModelState.IsValid)
            {
                DAL.UpdateBook(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        [Authorize(Roles = "Admin")]
        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = DAL.FindById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        [Authorize(Roles = "Admin")]
        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DAL.DeleteBook(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                DAL.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
