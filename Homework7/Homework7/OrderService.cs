using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework7
{
    class OrderService
    {

        private Dictionary<uint, Order> OrderDict;

        public List<Order> OrderList;

        public OrderService()
        {
            OrderList = new List<Order>();
            OrderDict = new Dictionary<uint, Order>();
        }

        public void AddOrder(Order order)
        {
            OrderList.Add(order);
            OrderDict[order.Id] = order;
        }

        public void RemoveOrder(uint orderId)
        {
            OrderDict.Remove(orderId);
        }

        public List<Order> QueryAllOrders()
        {
            return OrderDict.Values.ToList();
        }

        public Order GetById(uint orderId)
        {
            return OrderDict[orderId];
        }

        public List<Order> QueryByGoodsName(string goodsName)
        {
            List<Order> result = new List<Order>();
            foreach (Order order in OrderDict.Values)
            {
                foreach (OrderDetail detail in order.Details)
                {
                    if (detail.Goods.Name == goodsName)
                    {
                        result.Add(order);
                        break;
                    }
                }
            }
            return result;
        }

        public List<Order> QueryByCustomerName(string customerName)
        {
            var query = OrderDict.Values
                .Where(order => order.Customer.Name == customerName);
            return query.ToList();
        }

        public List<Order> QueryByTotalGoodsPrice(double price)
        {
            var query = OrderDict.Values
                .Where(order => order.GetTotalGoodsPrice() >= price);
            return query.ToList();
        }

        public void UpdateCustomer(uint orderId, Customer newCustomer)
        {
            if (OrderDict.ContainsKey(orderId))
            {
                OrderDict[orderId].Customer = newCustomer;
            }
            else
            {
                throw new Exception($"order-{orderId} is not existed!");
            }
        }
    }
}
