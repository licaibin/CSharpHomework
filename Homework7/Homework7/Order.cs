using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Homework7
{
    [Serializable]
    public class Order
    {
        private List<OrderDetail> details = new List<OrderDetail>();

        public uint Id { get; set; }

        public string CustomerName { get; set; }
        public Customer Customer { get; set; }

        public String AllGoods { get; set; }

        public int AllPrice { get; set; }

        public Order()
        {

        }

        public Order(uint orderId, Customer customer)
        {
            Id = orderId;
            CustomerName = customer.Name;
            Customer = customer;
            AllGoods = "";
            AllPrice = 0;
        }

        public List<OrderDetail> Details
        {
            get => this.details;
        }

        public void AddDetails(OrderDetail orderDetail)
        {
            if (this.Details.Contains(orderDetail))
            {
                throw new Exception($"orderDetails-{orderDetail.Id} is already existed!");
            }
            details.Add(orderDetail);

            AllGoods = "";
            foreach(OrderDetail item in Details)
            {
                AllGoods = AllGoods + item.Goods.Name + " * " + item.Quantity + "   ";
            }

            AllPrice = 0;
            foreach (OrderDetail item in Details)
            {
                AllPrice = Convert.ToInt32(AllPrice + item.Quantity * item.Goods.Price);
            }
        }

        public void RemoveDetails(uint orderDetailId)
        {
            details.RemoveAll(d => d.Id == orderDetailId);
        }

        public override string ToString()
        {
            string result = "================================================================================\n";
            result += $"orderId:{Id}, customer:({Customer})";
            details.ForEach(od => result += "\n\t" + od);
            result += "\n================================================================================";
            return result;
        }

        public double GetTotalGoodsPrice()
        {
            double totalPrice = 0;
            foreach (OrderDetail item in Details)
            {
                totalPrice += (item.Goods.Price * item.Quantity);
            }
            return totalPrice;
        }
    }
}
