using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace TheChopHouse.Models
{
    public class Customer
    {
        public int id { get; set; }

        public string firstName { get; set; }

        public string lastName { get; set; }

        public int balanceDue { get; set; }

        public Customer()
        {
        }

        public List<Customer> CustomerList()
        {
            SqlConnection con = new SqlConnection("server=localhost,1433; database=TheChopHouse; User ID=sa; Password=Strong.Pwd-123");

            SqlCommand cmd = new SqlCommand("select * from customers", con);
            List<Customer> ilist = new List<Customer>();
            SqlDataReader readAllCustomers = null;
            try
            {
                con.Open();
                readAllCustomers = cmd.ExecuteReader();

                while (readAllCustomers.Read())
                {
                    ilist.Add(new Customer()
                    {
                        id = Convert.ToInt32(readAllCustomers[0]),
                        firstName = readAllCustomers[1].ToString(),
                        lastName = readAllCustomers[2].ToString(),
                    });
                }

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                readAllCustomers.Close();
                con.Close();
            }
            return ilist;


        }

        public Customer GetCustomer(int customerId)
        {
            //check for validity for Customer ID
            Customer cust = new Customer();
            List<Customer> clist = cust.CustomerList();
            if (customerId < 1 || customerId > clist.Count)
            {
                throw new Exception("Please enter a valid customer ID");
            }

            SqlConnection con = new SqlConnection("server=localhost,1433; database=TheChopHouse; User ID=sa; Password=Strong.Pwd-123");

            SqlCommand cmd = new SqlCommand("select * from customers where customer_id=@id", con);
            cmd.Parameters.AddWithValue("@id", customerId);
            SqlDataReader read_customer = null;
            Customer cr = new Customer();
            try
            {
                con.Open();
                read_customer = cmd.ExecuteReader();

                if (read_customer.Read())
                {
                    cr.id = Convert.ToInt32(read_customer[0]);
                    cr.firstName = read_customer[1].ToString();
                    cr.lastName = read_customer[2].ToString();
                }
                else
                {
                    throw new Exception("Customer not found");
                }
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
            finally
            {
                read_customer.Close();
                con.Close();
            }
            return cr;
        }


        public string addCustomer(Customer newCustomer)
        {
            SqlConnection con = new SqlConnection("server=localhost,1433; database=TheChopHouse; User ID=sa; Password=Strong.Pwd-123");

            SqlCommand cmd = new SqlCommand("insert into customers (customer_first_name, customer_last_name) " +
                "values (@firstName, @lastName)", con);
            cmd.Parameters.AddWithValue("@firstName", newCustomer.firstName);
            cmd.Parameters.AddWithValue("@lastName", newCustomer.lastName);
            try
            {
                con.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception es)
            {
                throw new Exception(es.Message);
            }
            finally
            {
                con.Close();
            }
            return "Customer Added Successfully!";
        }

        public int customerInvoice(int customerId)
        {
            //check for validity for Customer ID
            Customer cust = new Customer();
            List<Customer> clist = cust.CustomerList();
            if (customerId < 1 || customerId > clist.Count)
            {
                throw new Exception("Please enter a valid customer ID");
            }

            SqlConnection con = new SqlConnection("server=localhost,1433; database=TheChopHouse; User ID=sa; Password=Strong.Pwd-123");

            SqlCommand cmd = new SqlCommand("select total from orders where customer_id=@id", con);
            cmd.Parameters.AddWithValue("@id", customerId);
            //List<Int32> tlist = new List<Int32>();
            int balance = 0;
            SqlDataReader readTotals = null;
            try
            {
                con.Open();
                readTotals = cmd.ExecuteReader();

                while (readTotals.Read())
                {
                    //tlist.Add(Convert.ToInt32(readAllCustomers[0]));
                    balance += Convert.ToInt32(readTotals[0]);
                }

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                readTotals.Close();
                con.Close();
            }
            return balance;
        }
    }
}
