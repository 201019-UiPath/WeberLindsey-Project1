using Xunit;
using StoreDB.Models;
using StoreDB;
using System.Linq;
using System.Collections.Generic;
using System;

namespace StoreTest
{
    public class OrderTest
    {
        [Fact]
        public void AddOrderShouldAdd(){
            using var testContext = new StoreContext();
            IOrderRepo repo = new DBRepo(testContext);
            
            Order testOrder = new Order();
            testOrder.userId = 1;
            testOrder.locationId = 1;
            testOrder.orderDate = DateTime.Now;
            testOrder.totalPrice = 10.50;

            repo.AddOrder(testOrder);

            Assert.NotNull(testContext.Orders.Single(o => o.orderDate == testOrder.orderDate));

            repo.DeleteOrder(testOrder);
        }

        [Fact]
        public void GetOrdersByLocationIdShouldGet() {
            using var testContext = new StoreContext();
            IOrderRepo repo = new DBRepo(testContext);        

            List<Order> result = repo.GetAllOrdersByLocationId(1);

            Assert.NotNull(result);
        }

        [Fact]
        public void GetAllOrdersByUserIdGetAll() {
            using var testContext = new StoreContext();
            IOrderRepo repo = new DBRepo(testContext);
            
            List<Order> result = repo.GetAllOrdersByUserId(1);

            Assert.NotNull(result);
        }

        [Fact]
        public void UpdateOrderShouldUpdate() {
            using var testContext = new StoreContext();
            IOrderRepo repo = new DBRepo(testContext);
            
            Order testOrder = new Order();
            testOrder.userId = 1;
            testOrder.locationId = 1;
            testOrder.orderDate = DateTime.Now;
            testOrder.totalPrice = 0;
            repo.AddOrder(testOrder);

            testOrder.totalPrice = 20.00;
            repo.UpdateOrder(testOrder);
            var result = repo.GetOrderByDate(testOrder.orderDate);

            Assert.Equal(20.00, result.totalPrice);

            repo.DeleteOrder(testOrder);
        }
    }
}