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
    [Authorize(Roles = "Admin")]
    [RequireHttps]
    public class LibraryCardsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LibraryCards
        public ActionResult Index()
        {
            return View(db.LibraryCards.ToList());
        }

        // GET: LibraryCards/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibraryCard libraryCard = db.LibraryCards.Find(id);
            if (libraryCard == null)
            {
                return HttpNotFound();
            }
            return View(libraryCard);
        }

        // GET: LibraryCards/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LibraryCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LibraryCardId,FirstName,LastName,DateOfBirth,Phone,Email")] LibraryCard libraryCard)
        {
            if (ModelState.IsValid)
            {
                db.LibraryCards.Add(libraryCard);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(libraryCard);
        }

        // GET: LibraryCards/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibraryCard libraryCard = db.LibraryCards.Find(id);
            if (libraryCard == null)
            {
                return HttpNotFound();
            }
            return View(libraryCard);
        }

        // POST: LibraryCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LibraryCardId,FirstName,LastName,DateOfBirth,Phone,Email")] LibraryCard libraryCard)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libraryCard).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(libraryCard);
        }

        // GET: LibraryCards/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibraryCard libraryCard = db.LibraryCards.Find(id);
            if (libraryCard == null)
            {
                return HttpNotFound();
            }
            return View(libraryCard);
        }

        // POST: LibraryCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LibraryCard libraryCard = db.LibraryCards.Find(id);
            db.LibraryCards.Remove(libraryCard);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
