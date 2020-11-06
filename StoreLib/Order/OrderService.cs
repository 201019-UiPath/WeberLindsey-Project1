using StoreDB.Models;
using StoreDB;
using System.Collections.Generic;
using System;

namespace StoreLib
{
    public class OrderService : IOrderService
    {
        private IOrderRepo repo;

        public OrderService(IOrderRepo repo)
        {
            this.repo = repo;
        }

        public void AddOrder(Order order)
        {
            repo.AddOrder(order);
        }
        public void UpdateOrder(Order order)
        {
            repo.UpdateOrder(order);
        }
        public Order GetOrderById(int id)
        {
            Order order = repo.GetOrderById(id);
            return order;
        }
        public Order GetOrderByUserId(int id)
        {
            Order order = repo.GetOrderByUserId(id);
            return order;
        }
        public Order GetOrderByLocationId(int id)
        {
            Order order = repo.GetOrderByLocationId(id);
            return order;
        }
        public List<Order> GetAllOrdersByLocationId(int id)
        {
            List<Order> orders = repo.GetAllOrdersByLocationId(id);
            return orders;
        }
        public List<Order> GetAllOrdersByUserId(int id)
        {
            List<Order> orders = repo.GetAllOrdersByUserId(id);
            return orders;
        }
        public void DeleteOrder(Order order)
        {
            repo.DeleteOrder(order);
        }

        public List<Order> GetAllOrdersByUserIdDateAsc(int id)
        {
            List<Order> orders = repo.GetAllOrdersByUserIdDateAsc(id);
            return orders;
        }
        public List<Order> GetAllOrdersByUserIdDateDesc(int id)
        {
            List<Order> orders = repo.GetAllOrdersByUserIdDateDesc(id);
            return orders;
        }
        public List<Order> GetAllOrdersByUserIdPriceAsc(int id)
        {
            List<Order> orders = repo.GetAllOrdersByUserIdPriceAsc(id);
            return orders;
        }
        public List<Order> GetAllOrdersByUserIdPriceDesc(int id)
        {
            List<Order> orders = repo.GetAllOrdersByUserIdPriceDesc(id);
            return orders;
        }

        public Order GetOrderByDate(DateTime dateTime)
        {
            Order order = repo.GetOrderByDate(dateTime);
            return order;
        }
    }
}