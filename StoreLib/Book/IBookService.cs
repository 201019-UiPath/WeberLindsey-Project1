using System.Collections.Generic;
using StoreDB.Models;

namespace StoreLib
{
    public interface IBookService
    {
        void AddBook(Book book);
        void DeleteBook(Book book);
        List<Book> GetAllBooks();
        List<Book> GetAllBooksAtLocationId(int id);
        Book GetBookById(int id);
        Book GetBookByTitle(string title);
        void UpdateBook(Book book);
    }
}