using System.Linq;

namespace LibraryManagementSystem_A2.Models
{
    public interface IBookDAL
    {
        void DeleteBook(int id);
        void Dispose();
        Book FindById(int? id);
        IQueryable<Book> GetAllBooks();
        void SaveNewBook(Book book);
        void UpdateBook(Book book);
    }
}