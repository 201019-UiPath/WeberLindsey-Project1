using StoreDB.Models;
using System.Collections.Generic;

namespace StoreDB.Repos
{
    public interface ICartItemRepo
    {
         void AddCartItem(CartItem cartItem);
         void UpdateCartItem(CartItem cartItem);
         CartItem GetCartItemById(int id);
         CartItem GetCartItemByCartId(int id);
         List<CartItem> GetAllCartItemsByCartId(int id);
         void DeleteCartItem(CartItem cartItem);
    }
}