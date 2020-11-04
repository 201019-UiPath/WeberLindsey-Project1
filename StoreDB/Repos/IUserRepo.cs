using StoreDB.Models;
using System.Collections.Generic;

namespace StoreDB.Repos
{
    public interface IUserRepo
    {
         void AddUser(User user);
         void UpdateUser(User user);
         User GetUserById(int id);
         User GetUserByUsername(string username);
         List<User> GetAllUsers();
         void DeleteUser(User user);
    }
}