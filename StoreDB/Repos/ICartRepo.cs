using StoreDB.Models;
using System.Collections.Generic;

namespace StoreDB.Repos
{
    public interface ICartRepo
    {
         void AddCart(Cart cart);
         void UpdateCart(Cart cart);
         Cart GetCartById(int id);
         Cart GetCartByUserId(int id);
         void DeleteCart(Cart cart);
    }
}