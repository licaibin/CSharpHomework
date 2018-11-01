using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Homework7
{
    public partial class Form1 : Form
    {
        OrderService orderService = new OrderService();
        public string KeyWord { get; set; }

        public Form1()
        {
            InitializeComponent();

            Customer customer1 = new Customer(1, "Customer1");
            Customer customer2 = new Customer(2, "Customer2");

            Goods milk = new Goods(1, "Milk", 69.9);
            Goods eggs = new Goods(2, "eggs", 4.99);
            Goods apple = new Goods(3, "apple", 5.59);

            OrderDetail orderDetails1 = new OrderDetail(1, apple, 8);
            OrderDetail orderDetails2 = new OrderDetail(2, eggs, 2);
            OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);

            Order order1 = new Order(1, customer1);
            Order order2 = new Order(2, customer2);
            Order order3 = new Order(3, customer2);
            order1.AddDetails(orderDetails1);
            order1.AddDetails(orderDetails2);
            order1.AddDetails(orderDetails3);
            order2.AddDetails(orderDetails2);
            order2.AddDetails(orderDetails3);
            order3.AddDetails(orderDetails3);

            orderService.AddOrder(order1);
            orderService.AddOrder(order2);
            orderService.AddOrder(order3);

            bindingSource1.DataSource = orderService.OrderList;

            textBox1.DataBindings.Add("Text", this, "KeyWord");
        }



        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (KeyWord == "")
                {
                    bindingSource1.DataSource =
                        orderService.OrderList;
                }
                else
                {
                    bindingSource1.DataSource =
                        orderService.OrderList.Where(order => order.Customer.Name == KeyWord);
                }
            }
            catch (Exception)
            {
                bindingSource1.DataSource =
                    orderService.OrderList;
                MessageBox.Show("未找到该客户");
            }
        }
    }
}
