using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class SubSystems
    {
        private IUOW uow;

        public SubSystems(IUOW swich)
        {
            this.uow = swich;
        }

        // PUT

        public String EditProduct(Dictionary<String, String> product, Dictionary<String, String> user)
        {
            if (user["Status"] == "Manager" || user["Status"] == "Admin")
            {
                this.uow.UpdateProduct(product);
                return "Complete";
            }
            return "Permition denied";
        }

        // GET

        public Dictionary<String,String>[] GetProductsSearch(String search)
        {
            var response = new List<Dictionary<String, String>>();
            foreach(var i in uow.ReadAllProducts())
            {
                if (search == null || i["Name"].Contains(search))
                {
                    response.Add(i);
                }
            }
            return this.Sort(response.ToArray());
        }

        public Dictionary<String, String>[] GetOrders(Dictionary<String, String> user)
        {
            if (user["Status"] == "Manager")
            {
                return this.uow.ReadAllOrders();
            }
            return new Dictionary<string, string>[]{ new Dictionary<string, string> { { user["Status"],"Permittion Denied" } } };
        }

        public Dictionary<String, float> Statistics()
        {
            var response = new Dictionary<String, float>();
            foreach (var i in uow.ReadAllOrders())
            {
                if (response.ContainsKey(i["UserId"]))
                {
                    response[i["UserId"]] += float.Parse(i["Price"]);
                    response[i["UserId"] + "C"] += 1;
                    continue;
                }
                response[i["UserId"]] = float.Parse(i["Price"]);
                response[i["UserId"] + "C"] = 1;
            }
            return response;
        }

        // POST

        public String Order(Dictionary<String, String> order, Dictionary<String, String> user)
        {
            if (user["Status"] == "Registered")
            {
                this.uow.CreateOrder(order);
                return "Complete";
            }
            return "Permition denied";
        }

        public String AddProduct(Dictionary<String, String> product, Dictionary<String, String> user)
        {
            if (user["Status"] == "Manager" || user["Status"] == "Admin")
            {
                this.uow.CreateProduct(product);
                return "Complete";
            }
            return "Permition denied";
        }

        public String AddUser(Dictionary<String, String> user)
        {
            try
            {
                this.uow.CreateUser(user);
                return "Complete";
            }
            catch (Exception e)
            {
                return "Incomplete";
            }
        }

        public Dictionary<String, String>[] GetProductsFilter(Dictionary<String, String> searched)
        {
            var response = new List<Dictionary<String, String>>();
            foreach (var i in uow.ReadAllProducts())
            {
                if (i["Price"].Contains(searched["Price"]) && i["Name"].Contains(searched["Name"]) && i["Description"].Contains(searched["Description"]))
                {
                    response.Add(i);
                }
            }
            return this.Sort(response.ToArray());
        }

        // DELETE

        public String DeleteOrder(Dictionary<String, String> order, Dictionary<String, String> user)
        {
            if (user["Status"] == "Manager" || user["Status"] == "Registered")
            {
                this.uow.DeleteOrder(order);
                return "Complete";
            }
            return "Permission denied";
        }

        private Dictionary<String, String>[] Sort(Dictionary<String, String>[] arr)
        {
            for (int i = 0; i < arr.Count(); i++)
            {
                var item = arr[i];
                var currentIndex = i;
                while (currentIndex > 0 && float.Parse(arr[currentIndex - 1]["Price"]) > float.Parse(item["Price"]))
                {
                    arr[currentIndex] = arr[currentIndex - 1];
                    currentIndex--;
                }
                arr[currentIndex] = item;
            }
            return arr;
        }
    }
}
