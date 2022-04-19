using System;
using System.Collections.Generic;
using System.Data.SqlClient;
namespace TheChopHouse.Models
{
    public class Item
    {
        public int id { get; set; }

        public string name { get; set; }

        public string description { get; set; }

        public int price { get; set; }

        public Item()
        {

        }

        public List<Item> allItemsList()
        {
            SqlConnection con = new SqlConnection("server=localhost,1433; database=TheChopHouse; User ID=sa; Password=Strong.Pwd-123");

            SqlCommand cmd = new SqlCommand("select * from items", con);
            List<Item> ilist = new List<Item>();
            SqlDataReader readAllItems = null;
            try
            {
                con.Open();
                readAllItems = cmd.ExecuteReader();

                while (readAllItems.Read())
                {
                    ilist.Add(new Item()
                    {
                        id = Convert.ToInt32(readAllItems[0]),
                        name = readAllItems[1].ToString(),
                        description = readAllItems[2].ToString(),
                        price = Convert.ToInt32(readAllItems[3]),
                    });
                }

            }
            catch (SqlException ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                readAllItems.Close();
                con.Close();
            }
            return ilist;
        }

        public Item GetItem(int itemId)
        {
            SqlConnection con = new SqlConnection("server=localhost,1433; database=TheChopHouse; User ID=sa; Password=Strong.Pwd-123");

            SqlCommand cmd = new SqlCommand("select * from items where item_id=@itemId", con);
            cmd.Parameters.AddWithValue("@itemId", itemId);
            SqlDataReader read_item = null;
            Item ir = new Item();
            try
            {
                con.Open();
                read_item = cmd.ExecuteReader();

                if (read_item.Read())
                {
                    ir.id = Convert.ToInt32(read_item[0]);
                    ir.name = read_item[1].ToString();
                    ir.description = read_item[2].ToString();
                    ir.price = Convert.ToInt32(read_item[3]);
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
                read_item.Close();
                con.Close();
            }
            return ir;
        }

    }
}
