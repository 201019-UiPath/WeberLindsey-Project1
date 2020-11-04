using StoreDB.Repos;
using StoreDB.Models;
using System.Collections.Generic;

namespace StoreLib
{
    public class CartItemService
    {

        private ICartItemRepo repo;

        public CartItemService(ICartItemRepo repo) {
            this.repo = repo;
        }

        public void AddCartItem(CartItem cartItem) {
             repo.AddCartItem(cartItem);
         }
        public void UpdateCartItem(CartItem cartItem) {
             repo.UpdateCartItem(cartItem);
         }
        public CartItem GetCartItemById(int id) {
             CartItem item = repo.GetCartItemById(id);
             return item;
         }
        public CartItem GetCartItemByCartId(int id) {
             CartItem item = repo.GetCartItemByCartId(id);
             return item;
         }
        public List<CartItem> GetAllCartItemsByCartId(int id) {
             List<CartItem> items = repo.GetAllCartItemsByCartId(id);
             return items;
         }
        public void DeleteCartItem(CartItem cartItem) {
             repo.DeleteCartItem(cartItem);
         }
    }
}