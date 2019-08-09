﻿using System;
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
    public class LibraryBranchesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: LibraryBranches
        public ActionResult Index()
        {
            return View(db.LibraryBranches.ToList());
        }

        // GET: LibraryBranches/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibraryBranch libraryBranch = db.LibraryBranches.Find(id);
            if (libraryBranch == null)
            {
                return HttpNotFound();
            }
            return View(libraryBranch);
        }

        // GET: LibraryBranches/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LibraryBranches/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LibraryBranchId,Name,Address,Phone,Hours")] LibraryBranch libraryBranch)
        {
            if (ModelState.IsValid)
            {
                db.LibraryBranches.Add(libraryBranch);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(libraryBranch);
        }

        // GET: LibraryBranches/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibraryBranch libraryBranch = db.LibraryBranches.Find(id);
            if (libraryBranch == null)
            {
                return HttpNotFound();
            }
            return View(libraryBranch);
        }

        // POST: LibraryBranches/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LibraryBranchId,Name,Address,Phone,Hours")] LibraryBranch libraryBranch)
        {
            if (ModelState.IsValid)
            {
                db.Entry(libraryBranch).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(libraryBranch);
        }

        // GET: LibraryBranches/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LibraryBranch libraryBranch = db.LibraryBranches.Find(id);
            if (libraryBranch == null)
            {
                return HttpNotFound();
            }
            return View(libraryBranch);
        }

        // POST: LibraryBranches/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LibraryBranch libraryBranch = db.LibraryBranches.Find(id);
            db.LibraryBranches.Remove(libraryBranch);
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
