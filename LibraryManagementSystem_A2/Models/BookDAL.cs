using System;
using System.Collections.Generic;
using System.Linq;
using System.Data;
using System.Data.Entity;
using System.Web;

namespace LibraryManagementSystem_A2.Models
{
    public class BookDAL : IBookDAL
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IQueryable<Book> GetAllBooks()
        {
            return db.Books;
        }

        public Book FindById(int? id)
        {
            return db.Books.Find(id);
        }

        public void SaveNewBook(Book book)
        {
            db.Books.Add(book);
            db.SaveChanges();
        }

        public void UpdateBook(Book book)
        {
            db.Entry(book).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void DeleteBook(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }
    
            
    }
}