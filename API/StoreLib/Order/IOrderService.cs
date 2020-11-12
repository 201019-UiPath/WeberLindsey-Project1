using System;
using System.Collections.Generic;
using StoreDB.Models;

namespace StoreLib
{
    public interface IOrderService
    {
        void AddOrder(Order order);
        void DeleteOrder(Order order);
        List<Order> GetAllOrdersByLocationId(int id);
        List<Order> GetAllOrdersByUserId(int id);
        List<Order> GetAllOrdersByUserIdDateAsc(int id);
        List<Order> GetAllOrdersByUserIdDateDesc(int id);
        List<Order> GetAllOrdersByUserIdPriceAsc(int id);
        List<Order> GetAllOrdersByUserIdPriceDesc(int id);
        Order GetOrderByDate(DateTime dateTime);
        Order GetOrderById(int id);
        Order GetOrderByLocationId(int id);
        Order GetOrderByUserId(int id);
        void UpdateOrder(Order order);
    }
}