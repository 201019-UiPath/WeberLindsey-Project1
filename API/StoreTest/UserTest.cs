using Xunit;
using StoreDB.Models;
using StoreDB;
using StoreDB.Repos;
using System.Linq;
using System.Collections.Generic;

namespace StoreTest
{
    public class UserTest
    {

        [Fact]
        public void AddUserShouldAdd(){
            using var testContext = new StoreContext();
            IUserRepo repo = new DBRepo(testContext);
            
            User testUser = new User();
            testUser.name = "Test Name";
            testUser.email = "testUser@email.com";
            testUser.username = "TestUser";
            testUser.password = "password";
            testUser.locationId = 1;

            repo.AddUser(testUser);

            Assert.NotNull(testContext.Users.Single(u => u.name == testUser.name));

            repo.DeleteUser(testUser);
        }

        [Fact]
        public void GetUserByUsernameShouldGet() {
            using var testContext = new StoreContext();
            IUserRepo repo = new DBRepo(testContext);

            User testUser = new User();
            testUser.name = "Test Name";
            testUser.email = "testUser@email.com";
            testUser.username = "TestUser";
            testUser.password = "password";
            testUser.locationId = 1;
            repo.AddUser(testUser);            

            User result = repo.GetUserByUsername(testUser.username);

            Assert.NotNull(result);

            repo.DeleteUser(testUser);
        }

        [Fact]
        public void GetAllUsersShouldGetAll() {
            using var testContext = new StoreContext();
            IUserRepo repo = new DBRepo(testContext);
            
            List<User> result = repo.GetAllUsers();

            Assert.NotNull(result);
        }

        [Fact]
        public void UpdateUserShouldUpdate() {
            using var testContext = new StoreContext();
            IUserRepo repo = new DBRepo(testContext);
            
            User testUser = new User();
            testUser.name = "Test Name";
            testUser.email = "testUser@email.com";
            testUser.username = "TestUser";
            testUser.password = "password";
            testUser.locationId = 1;
            repo.AddUser(testUser);

            testUser.name = "Different Test Name";
            repo.UpdateUser(testUser);
            var result = repo.GetUserByUsername(testUser.username);

            Assert.Equal("Different Test Name", result.name);

            repo.DeleteUser(testUser);
        }

    }
}
