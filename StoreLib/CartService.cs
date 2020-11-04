using StoreDB.Repos;
using StoreDB.Models;
using System.Collections.Generic;

namespace StoreLib
{
    public class CartService
    {

        private ICartRepo repo;

        public CartService(ICartRepo repo) {
            this.repo = repo;
        }

        public void AddCart(Cart cart) {
             repo.AddCart(cart);
         }

        public void UpdateCart(Cart cart) {
             repo.UpdateCart(cart);
         }

        public Cart GetCartById(int id) {
             Cart cart = repo.GetCartById(id);
             return cart;
         }

        public Cart GetCartByUserId(int id) {
             Cart cart = repo.GetCartByUserId(id);
             return cart;
         }

        public void DeleteCart(Cart cart) {
             repo.DeleteCart(cart);
         }
    }
}