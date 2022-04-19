using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace TheChopHouse.Models
{
	public class Order
	{
        public int id { get; set; }

        public DateTime date { get; set; }

        public int customerId { get; set; }

        public List<Item> orderItems { get; set; } = new List<Item>();

        public int orderTotal { get; set; } = 0;

        SqlConnection con = new SqlConnection("server=localhost,1433; database=TheChopHouse; User ID=sa; Password=Strong.Pwd-123");

		public Order()
		{
		}

		public Order GetOrder(int orderId)
        {
            //check for validity for Order ID
            Order ord = new Order();
            List<Order> clist = ord.OrderList();
            if (orderId < 1 || orderId > clist.Count)
            {
                throw new Exception("Please enter a valid order ID");
            }

            SqlCommand cmd = new SqlCommand("select * from orders where order_id=@orderId", con);
            cmd.Parameters.AddWithValue("@orderId", orderId);
            SqlDataReader read_order = null;
            Order or = new Order();
            try
            {
                con.Open();
                read_order = cmd.ExecuteReader();

                if(read_order.Read())
                {
                    or.id = Convert.ToInt32(read_order[0]);
                    or.date = Convert.ToDateTime(read_order[1]);
                    or.customerId = Convert.ToInt32(read_order[2]);
                    or.orderTotal = Convert.ToInt32(read_order[3]);
                }
                else
                {
                    throw new Exception("Order not found");
                }
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
            finally
            {
                read_order.Close();
                con.Close();
            }

            SqlCommand cmd_read_order_items = new SqlCommand("select * from order_items where order_id=@orderId", con);
            cmd_read_order_items.Parameters.AddWithValue("@orderId", orderId);
            List<Order_Item> oilist = new List<Order_Item>();
            SqlDataReader readAllOrderItems = null;
            try
            {
                con.Open();
                readAllOrderItems = cmd_read_order_items.ExecuteReader();

                while (readAllOrderItems.Read())
                {
                    oilist.Add(new Order_Item()
                    {
                        orderId = Convert.ToInt32(readAllOrderItems[1]),
                        itemId = Convert.ToInt32(readAllOrderItems[2])
                    });
                }

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                readAllOrderItems.Close();
                con.Close();
            }

            foreach (Order_Item order_item in oilist)
            {
                Item newItem = new Item().GetItem(order_item.itemId);
                or.orderItems.Add(newItem);
            }
            
            return or;
        }

        public List<Order> OrderList()
        {
            SqlConnection con = new SqlConnection("server=localhost,1433; database=TheChopHouse; User ID=sa; Password=Strong.Pwd-123");

            //get orders from order table
            SqlCommand cmd_read_orders = new SqlCommand("select * from orders", con);
            List<Order> olist = new List<Order>();
            SqlDataReader readAllOrders = null;
            try
            {
                con.Open();
                readAllOrders = cmd_read_orders.ExecuteReader();

                while (readAllOrders.Read())
                {
                    olist.Add(new Order()
                    {
                        id = Convert.ToInt32(readAllOrders[0]),
                        date = Convert.ToDateTime(readAllOrders[1]),
                        customerId = Convert.ToInt32(readAllOrders[2])
                    });
                }

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                readAllOrders.Close();
                con.Close();
            }

            return olist;
        }


        public List<Order> GetCustomerOrderHistory(int customerId)
        {
            //check for validity for Customer ID
            Customer cust = new Customer();
            List<Customer> clist = cust.CustomerList();
            if (customerId < 1 || customerId > clist.Count)
            {
                throw new Exception("Please enter a valid customer ID");
            }

            SqlCommand cmd= new SqlCommand("select * from orders where customer_id=@customerId", con);
            cmd.Parameters.AddWithValue("@customerId", customerId);
            List<Order> olist = new List<Order>();
            SqlDataReader read_orders = null;
            try
            {
                con.Open();
                read_orders = cmd.ExecuteReader();

                while (read_orders.Read())
                {
                    olist.Add(new Order()
                    {
                        id = Convert.ToInt32(read_orders[0]),
                        date = Convert.ToDateTime(read_orders[1]),
                        customerId = Convert.ToInt32(read_orders[2])
                    });
                }

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                read_orders.Close();
                con.Close();
            }

            foreach (Order order in olist)
            {
                SqlCommand cmd_read_order_items = new SqlCommand("select * from order_items where order_id=@orderId", con);
                cmd_read_order_items.Parameters.AddWithValue("@orderId", order.id);
                List<Order_Item> oilist = new List<Order_Item>();
                SqlDataReader readAllOrderItems = null;
                try
                {
                    con.Open();
                    readAllOrderItems = cmd_read_order_items.ExecuteReader();

                    while (readAllOrderItems.Read())
                    {
                        oilist.Add(new Order_Item()
                        {
                            orderId = Convert.ToInt32(readAllOrderItems[1]),
                            itemId = Convert.ToInt32(readAllOrderItems[2])
                        });
                    }

                }
                catch (SqlException ex)
                {
                    throw new Exception(ex.Message);
                }
                finally
                {
                    readAllOrderItems.Close();
                    con.Close();
                }

                foreach (Order_Item order_item in oilist)
                {
                    Item newItem = new Item().GetItem(order_item.itemId);
                    order.orderItems.Add(newItem);
                    order.orderTotal += newItem.price;
                }
            }

            return olist;
        }

        public string addOrder(Order order)
        {
            //check for validity for Customer ID
            Customer cust = new Customer();
            List<Customer> clist = cust.CustomerList();
            if(order.customerId < 1 || order.customerId > clist.Count)
            {
                throw new Exception("Please enter a valid customer ID");
            }

            //check for validity on items
            foreach(Item item in order.orderItems)
            {
                if(item.id < 1 || item.id > 74)
                {
                    throw new Exception("Invalid item ID.  Please have a look at the menu and enter a value from 1 to 74");
                }
            }
            SqlCommand cmd_add_order = new SqlCommand("insert into orders (order_date, customer_id) " +
                "values (@date, @customer_id)", con);
            cmd_add_order.Parameters.AddWithValue("@date", order.date);
            cmd_add_order.Parameters.AddWithValue("@customer_id", order.customerId);

            try
            {
                con.Open();
                cmd_add_order.ExecuteNonQuery();
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
            finally
            {
                con.Close();
            }

            List<Order> orderList = OrderList();
            int orderId = orderList.Count;

            
            foreach(Item item in order.orderItems)
            {
                order.orderTotal += item.price;
                SqlCommand cmd_order_items = new SqlCommand("insert into order_items (order_id, item_id) " +
                        "values (@orderId, @itemId)", con);
                cmd_order_items.Parameters.AddWithValue("@orderId", orderId);
                cmd_order_items.Parameters.AddWithValue("itemId", item.id);
                try
                {
                    con.Open();
                    cmd_order_items.ExecuteNonQuery();
                }
                catch (Exception es)
                {
                    throw new Exception(es.Message);
                }
                finally
                {
                    con.Close();
                }
            }

            SqlCommand cmd_update_total = new SqlCommand("update orders set total=@total where order_id=@orderId", con);
            cmd_update_total.Parameters.AddWithValue("@total", order.orderTotal);
            cmd_update_total.Parameters.AddWithValue("@orderId", orderId);
            try
            {
                con.Open();
                cmd_update_total.ExecuteNonQuery();
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
            finally
            {
                con.Close();
            }
            return "Order Added Successfully!";
        }

		public string DeleteOrder(int orderId)
        {
            return "";
        }


		public string UpdateOrder(Order updates)
        {
            return "";
        }

	}
}

