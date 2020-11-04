using StoreDB.Models;
using StoreDB.Repos;
using System.Collections.Generic;

namespace StoreLib
{
    public class UserService
    {

        private IUserRepo repo;

        public UserService(IUserRepo repo) {
            this.repo = repo;
        }

        public void AddUser(User user) {
            repo.AddUser(user);
        }

        public void UpdateUser(User user) {
             repo.UpdateUser(user);
         }

        public User GetUserById(int id) {
             User user = GetUserById(id);
             return user;
         }

        public User GetUserByUsername(string username) {
             User user = repo.GetUserByUsername(username);
             return user;
         }

        public List<User> GetAllUsers() {
             List<User> users = repo.GetAllUsers();
             return users;
         }

        public void DeleteUser(User user) {
             repo.DeleteUser(user);
         }
        
                          
        
    }
}
