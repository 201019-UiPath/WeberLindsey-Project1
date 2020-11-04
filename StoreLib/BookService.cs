using StoreDB.Repos;
using StoreDB.Models;
using System.Collections.Generic;

namespace StoreLib
{
    public class BookService
    {
        private IBookRepo repo;

        public BookService(IBookRepo repo) {
            this.repo = repo;
        }

        public void AddBook(Book book) {
            repo.AddBook(book);
        }

        public void UpdateBook(Book book) {
             repo.UpdateBook(book);
         }

        public Book GetBookById(int id) {
             Book book = repo.GetBookById(id);
             return book;
         }

        public Book GetBookByTitle(string title) {
             Book book = repo.GetBookByTitle(title);
             return book;
         }

        public List<Book> GetAllBooks() {
             List<Book> books = repo.GetAllBooks();
             return books;
         }

        public List<Book> GetAllBooksAtLocationId(int id) {
             List<Book> books = repo.GetAllBooksAtLocationId(id);
             return books;
         }

        public void DeleteBook(Book book) {
             repo.DeleteBook(book);
         }

        
    }
}