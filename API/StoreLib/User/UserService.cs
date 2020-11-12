using Serilog;
using StoreDB.Models;
using StoreDB.Repos;
using System;
using System.Collections.Generic;

namespace StoreLib
{
    public class UserService : IUserService
    {

        private IUserRepo repo;

        public UserService(IUserRepo repo)
        {
            this.repo = repo;
        }

        public void AddUser(User user)
        {
            repo.AddUser(user);
        }

        public void UpdateUser(User user)
        {
            repo.UpdateUser(user);
        }

        public User GetUserById(int id)
        {
            User user = GetUserById(id);
            return user;
        }

        public User GetUserByUsername(string username)
        {
            User user = repo.GetUserByUsername(username);
            return user;
        }

        public List<User> GetAllUsers()
        {
            List<User> users = repo.GetAllUsers();
            return users;
        }

        public void DeleteUser(User user)
        {
            repo.DeleteUser(user);
        }

       
        /*public void SignUp(User user)
        {
            List<User> users = GetAllUsers();
            if(ValidationService.ValidUsername(user.username, users) == false)
            {
                return BadRequest();
            }
            user.type = User.userType.Customer;

            AddUser(user);

            User createdUser = GetUserByUsername(user.username);

            Cart cart = new Cart();
            cart.userId = createdUser.id;
            cartService.AddCart(cart);
        }*/

    }
}
