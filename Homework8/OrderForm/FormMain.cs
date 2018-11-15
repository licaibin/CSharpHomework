using ordertest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using System.IO;
using System.Xml;
using System.Xml.XPath;
using System.Xml.Xsl;

namespace OrderForm
{
    public partial class FormMain : Form
    {
        OrderService orderService;
        BindingSource fieldsBS = new BindingSource();
        public FormMain()
        {
            InitializeComponent();
            init();
        }

        public void init()
        {
            Customer customer1 = new Customer(1, "liuwang");
            Customer customer2 = new Customer(2, "jams");

            Goods apple = new Goods(3, "apple", 5.59);
            Goods egg = new Goods(2, "egg", 4.99);
            Goods milk = new Goods(1, "milk", 69.9);

            OrderDetail orderDetails1 = new OrderDetail(1, apple, 8);
            OrderDetail orderDetails2 = new OrderDetail(2, egg, 2);
            OrderDetail orderDetails3 = new OrderDetail(3, milk, 1);

            Order order1 = new Order(20181115001, customer1, 11111111111);
            Order order2 = new Order(20181115002, customer2, 22222222222);
            Order order3 = new Order(20181115003, customer2, 33333333333);

            order1.AddDetails(orderDetails1);
            order1.AddDetails(orderDetails2);
            order1.AddDetails(orderDetails3);
            order2.AddDetails(orderDetails2);
            order2.AddDetails(orderDetails3);
            order3.AddDetails(orderDetails3);

            orderService = new OrderService();
            orderService.AddOrder(order1);
            orderService.AddOrder(order2);
            orderService.AddOrder(order3);

            orderBindingSource.DataSource = orderService.QueryAllOrders();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormEdit form2 = new FormEdit(new Order());
            form2.ShowDialog();
            Order newOrder = form2.getResult();
            if (newOrder!=null){

                bool idOK, phoneOK;
                Regex idRx = new Regex("20[0-9]{2}((0[0-9])|(1[12]))(([012][0-9])|(3[01]))[0-9]{3}");
                Regex phoneRx = new Regex("[0-9]{11}");
                idOK = idRx.IsMatch(Convert.ToString(newOrder.Id));
                phoneOK = phoneRx.IsMatch(Convert.ToString(newOrder.Phone));

                if (idOK)
                {
                    if (phoneOK)
                    {
                        orderService.AddOrder(newOrder);
                        orderBindingSource.DataSource = orderService.QueryAllOrders();
                    }
                    else
                    {
                        MessageBox.Show("用户手机格式不正确！");
                    }
                }
                else
                {
                    MessageBox.Show("订单号格式不正确！");
                }
            }
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            FormEdit form2 = new FormEdit((Order)orderBindingSource.Current);
            form2.ShowDialog();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Order o=(Order)orderBindingSource.Current;
            if (o != null)
            {
                orderService.RemoveOrder(o.Id);
                orderBindingSource.DataSource=orderService.QueryAllOrders();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                String fileName = saveFileDialog1.FileName;
                orderService.Export(fileName);
            }

        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result.Equals(DialogResult.OK))
            {
                String fileName = openFileDialog1.FileName;
                orderService.Import(fileName);
                orderBindingSource.DataSource = orderService.QueryAllOrders();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            switch (cbField.SelectedIndex)
            {
                case 0:
                    orderBindingSource.DataSource =
                        orderService.QueryAllOrders();
                    break;
                case 1:
                    ulong id = 0;
                    ulong.TryParse(txtValue.Text, out id);
                    orderBindingSource.DataSource = orderService.GetById(id);
                    break;
                case 2:
                    orderBindingSource.DataSource =
                            orderService.QueryByCustomerName(txtValue.Text);
                    break;
                case 3:
                    orderBindingSource.DataSource =
                            orderService.QueryByGoodsName(txtValue.Text);
                    break;
                case 4:
                    double price = 0;
                    double.TryParse(txtValue.Text, out price);
                    orderBindingSource.DataSource =
                           orderService.QueryByPrice(price);
                    break;
            }

        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            orderService.Export("order.xml");

            XmlDocument doc = new XmlDocument();
            doc.Load(@".\order.xml");

            XPathNavigator nav = doc.CreateNavigator();
            nav.MoveToRoot();

            XslCompiledTransform xt = new XslCompiledTransform();
            xt.Load(@".\x.xslt");

            FileStream outfile = File.OpenWrite("s.html");

            XmlTextWriter writer = new XmlTextWriter(outfile, System.Text.Encoding.UTF8);

            xt.Transform(nav, null, writer);
            outfile.Close();
        }
    }
}
