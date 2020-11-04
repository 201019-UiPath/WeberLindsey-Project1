using Xunit;
using StoreDB.Models;
using StoreDB;
using StoreDB.Repos;
using System.Linq;
using System.Collections.Generic;
using System;

namespace StoreTest
{
    public class BookTest
    {

        [Fact]
        public void AddBookShouldAdd(){
            using var testContext = new StoreContext();
            IBookRepo repo = new DBRepo(testContext);
            
            Book testBook = new Book();
            testBook.title = "Test Title";
            testBook.author = "Test Author";
            testBook.price = 5.00;
            testBook.synopsis = "Test Synopsis";

            repo.AddBook(testBook);

            Assert.NotNull(testContext.Books.Single(b => b.title == testBook.title));

            repo.DeleteBook(testBook);
        }

        [Fact]
        public void GetAllBooksShouldGetAll() {
            using var testContext = new StoreContext();
            IBookRepo repo = new DBRepo(testContext);

            List<Book> result = repo.GetAllBooks();

            Assert.NotNull(result);
        }

    }
}