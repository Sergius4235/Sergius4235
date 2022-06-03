using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    // mock 
    public class UOWTest: IUOW
    {
        public Dictionary<String, String> CreateOrder(Dictionary<String, String> order)
        {
            return order;
        }

        public Dictionary<String, String> CreateUser(Dictionary<String, String> user)
        {
            return user;
        }

        public Dictionary<String, String> CreateProduct(Dictionary<String, String> product)
        {
            return product;
        }


        public Dictionary<String, String>[] ReadAllOrders()
        {
            var dict = new List<Dictionary<String, String>>();
            return dict.ToArray();
        }

        public Dictionary<String, String>[] ReadAllUsers()
        {
            var dict = new List<Dictionary<String, String>>();
            return dict.ToArray();
        }

        public Dictionary<String, String>[] ReadAllProducts()
        {
            var dict = new List<Dictionary<String, String>>();
            return dict.ToArray();
        }


        public Dictionary<String, String> ReadOrder(int Id)
        {
            var order = new Dictionary<String, String>();
            order.Add("Id", "3");
            order.Add("Name", "Cake");
            order.Add("Price", "98");
            order.Add("Photo", "None");
            order.Add("Description", "None");
            return order;
        }

        public Dictionary<String, String> ReadUser(int Id)
        {
            var user = new Dictionary<String, String>();
            user.Add("Id", "3");
            user.Add("Name", "Cake");
            user.Add("Price", "98");
            user.Add("Photo", "None");
            user.Add("Description", "None");
            return user;
        }

        public Dictionary<String, String> ReadProduct(int Id)
        {
            var product = new Dictionary<String, String>();
            product.Add("Id", "3");
            product.Add("Name", "Cake");
            product.Add("Price", "98");
            product.Add("Photo", "None");
            product.Add("Description", "None");
            return product;
        }


        public void UpdateOrder(Dictionary<String, String> o) { }

        public void UpdateUser(Dictionary<String, String> o) { }

        public void UpdateProduct(Dictionary<String, String> o) { }


        public void DeleteProduct(Dictionary<String, String> o) { }

        public void DeleteUser(Dictionary<String, String> o) { }

        public void DeleteOrder(Dictionary<String, String> o) { }
    }
}
