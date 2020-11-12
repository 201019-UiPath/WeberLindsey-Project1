using System.Collections.Generic;
using StoreDB.Models;

namespace StoreLib
{
    public interface IUserService
    {
        void AddUser(User user);
        void DeleteUser(User user);
        List<User> GetAllUsers();
        User GetUserById(int id);
        User GetUserByUsername(string username);
        void UpdateUser(User user);
    }
}