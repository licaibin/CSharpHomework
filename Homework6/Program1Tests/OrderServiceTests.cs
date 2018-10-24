using Microsoft.VisualStudio.TestTools.UnitTesting;
using ordertest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ordertest.Tests
{
    [TestClass()]
    public class OrderServiceTests
    {
        [TestMethod()]
        public void AddOrderTest()
        {
            Customer cus = new Customer(283, "licaibin");
            Order order = new Order(001, cus);
            OrderService orderService = new OrderService();
            orderService.AddOrder(order);
            Assert.IsTrue(orderService != null);
        }

        [TestMethod()]
        public void RemoveOrderTest()
        {
            Customer cus1 = new Customer(283, "licaibin");
            Order order1 = new Order(001, cus1);
            Customer cus2 = new Customer(001, "null");
            Order order2 = new Order(002, cus2);
            OrderService orderService = new OrderService();
            orderService.AddOrder(order1);
            orderService.AddOrder(order2);

            orderService.RemoveOrder(001);
            Assert.IsTrue(orderService.orderDict.Count == 1);
        }

        [TestMethod()]
        public void QueryAllOrdersTest()
        {
            Customer cus1 = new Customer(283, "licaibin");
            Order order1 = new Order(001, cus1);
            Customer cus2 = new Customer(001, "null");
            Order order2 = new Order(002, cus2);
            OrderService orderService = new OrderService();
            orderService.AddOrder(order1);
            orderService.AddOrder(order2);

            List<Order> orderList = orderService.QueryAllOrders();
            Assert.IsTrue(orderList.Count == 2);

        }

        [TestMethod()]
        public void GetByIdTest()
        {
            Customer cus1 = new Customer(283, "licaibin");
            Order order1 = new Order(001, cus1);
            Customer cus2 = new Customer(001, "null");
            Order order2 = new Order(002, cus2);
            OrderService orderService = new OrderService();
            orderService.AddOrder(order1);
            orderService.AddOrder(order2);

            Order ord = orderService.GetById(001);
            Assert.IsTrue(ord.Customer.Name == "licaibin");
        }

        [TestMethod()]
        public void QueryByGoodsNameTest()
        {
            Customer cus1 = new Customer(283, "licaibin");
            Order order1 = new Order(001, cus1);

            Goods milk = new Goods(1, "Milk", 69.9);
            OrderDetail orderDetails = new OrderDetail(3, milk, 1);
            order1.AddDetails(orderDetails);

            OrderService orderService = new OrderService();
            orderService.AddOrder(order1);

            List<Order> orderList = orderService.QueryByGoodsName("Milk");
            Assert.IsTrue(orderList[0].Customer.Name == "licaibin");
        }

        [TestMethod()]
        public void QueryByCustomerNameTest()
        {
            Customer cus1 = new Customer(283, "licaibin");
            Order order1 = new Order(001, cus1);

            Goods milk = new Goods(1, "Milk", 69.9);
            OrderDetail orderDetails = new OrderDetail(3, milk, 1);
            order1.AddDetails(orderDetails);

            OrderService orderService = new OrderService();
            orderService.AddOrder(order1);

            List<Order> orderList = orderService.QueryByCustomerName("licaibin");
            Assert.IsTrue(orderList[0].Id == 001);
        }

        [TestMethod()]
        public void QueryByTotalGoodsPriceTest()
        {
            Customer cus1 = new Customer(283, "licaibin");
            Order order1 = new Order(001, cus1);

            Goods milk = new Goods(1, "Milk", 69.9);
            OrderDetail orderDetails = new OrderDetail(3, milk, 1);
            order1.AddDetails(orderDetails);

            OrderService orderService = new OrderService();
            orderService.AddOrder(order1);

            List<Order> orderList = orderService.QueryByTotalGoodsPrice(69.9);
            Assert.IsTrue(orderList[0].Id == 001);

        }

        [TestMethod()]
        public void UpdateCustomerTest()
        {
            Customer cus1 = new Customer(283, "licaibin");
            Order order1 = new Order(001, cus1);

            OrderService orderService = new OrderService();
            orderService.AddOrder(order1);

            Customer newCus1 = new Customer(283, "caibin");
            orderService.UpdateCustomer(001, newCus1);
            
            Assert.IsTrue(orderService.GetById(001).Customer.Name == "caibin");

        }

        [TestMethod()]
        public void ExportTest()
        {
            Customer cus1 = new Customer(283, "licaibin");
            Order order1 = new Order(001, cus1);
            OrderService orderService = new OrderService();
            orderService.AddOrder(order1);

            Assert.IsTrue(orderService.GetById(001).Customer.Name == "licaibin");

        }

        [TestMethod()]
        public void ImportTest()
        {
            Customer cus1 = new Customer(283, "licaibin");
            Order order1 = new Order(001, cus1);
            OrderService orderService = new OrderService();
            orderService.AddOrder(order1);

            Assert.IsTrue(orderService.GetById(001).Customer.Name == "licaibin");
        }
    }
}