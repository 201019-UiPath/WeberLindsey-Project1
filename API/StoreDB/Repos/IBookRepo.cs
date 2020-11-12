using StoreDB.Models;
using System.Collections.Generic;

namespace StoreDB.Repos
{
    public interface IBookRepo
    {
         void AddBook(Book book);
         void UpdateBook(Book book);
         Book GetBookById(int id);
         Book GetBookByTitle(string title);
         List<Book> GetAllBooks();
         List<Book> GetAllBooksAtLocationId(int id);
         void DeleteBook(Book book);
    }
}