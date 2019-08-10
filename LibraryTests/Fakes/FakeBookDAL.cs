using LibraryManagementSystem_A2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryTests.Fakes
{
    class FakeBookDAL : IBookDAL
    {
        public int bookDeleted = -1;

        public void DeleteBook(int id)
        {
            bookDeleted = id;
            return;
        }

        public void Dispose()
        {
            return;
        }

        public Book FindById(int? id)
        {
            if (id == 5)
            {
                return new Book()
                {
                    Isbn = 222,
                    Title = "MobyDick",
                    Year = 1999,
                    Author = "Herman Melville",
                    ImageUrl = null,
                    Location = null
                };
            }
            return null;
        }

        public IQueryable<Book> GetAllBooks()
        {
            List<Book> books = new List<Book>();
            books.Add(new Book()
            {
                Isbn = 223,
                Title = "MobyDick",
                Year = 1999,
                Author = "Herman Melville",
                ImageUrl = null,
                Location = null
            });
            books.Add(new Book()
            {
                Isbn = 224,
                Title = "MobyDick",
                Year = 1999,
                Author = "Herman Melville",
                ImageUrl = null,
                Location = null
            });
            return books.AsQueryable();
        }

        public void SaveNewBook(Book book)
        {
            return;
        }

        public void UpdateBook(Book book)
        {
            return;
        }
    }
}
