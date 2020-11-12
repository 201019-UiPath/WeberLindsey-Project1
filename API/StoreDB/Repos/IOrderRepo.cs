using StoreDB.Models;
using System;
using System.Collections.Generic;

namespace StoreDB
{
    public interface IOrderRepo
    {
         void AddOrder(Order order);
         void UpdateOrder(Order order);
         Order GetOrderById(int id);
         Order GetOrderByUserId(int id);
         Order GetOrderByLocationId(int id);
         List<Order> GetAllOrdersByLocationId(int id);
         List<Order> GetAllOrdersByUserId(int id);
         void DeleteOrder(Order order);

         List<Order> GetAllOrdersByUserIdDateAsc(int id);
         List<Order> GetAllOrdersByUserIdDateDesc(int id);
         List<Order> GetAllOrdersByUserIdPriceAsc(int id);
         List<Order> GetAllOrdersByUserIdPriceDesc(int id);
         
         Order GetOrderByDate(DateTime dateTime);
    }
}