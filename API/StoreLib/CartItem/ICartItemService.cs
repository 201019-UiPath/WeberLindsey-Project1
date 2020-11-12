using System.Collections.Generic;
using StoreDB.Models;

namespace StoreLib
{
    public interface ICartItemService
    {
        void AddCartItem(CartItem cartItem);
        void DeleteCartItem(CartItem cartItem);
        List<CartItem> GetAllCartItemsByCartId(int id);
        CartItem GetCartItemByCartId(int id);
        CartItem GetCartItemById(int id);
        void UpdateCartItem(CartItem cartItem);
    }
}