using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public interface IUOW
    {
        Dictionary<String, String> CreateOrder(Dictionary<String, String> order);

        Dictionary<String, String> CreateUser(Dictionary<String, String> user);

        Dictionary<String, String> CreateProduct(Dictionary<String, String> product);


        Dictionary<String, String>[] ReadAllOrders();

        Dictionary<String, String>[] ReadAllUsers();

        Dictionary<String, String>[] ReadAllProducts();


        Dictionary<String, String> ReadOrder(int Id);

        Dictionary<String, String> ReadUser(int Id);

        Dictionary<String, String> ReadProduct(int Id);


        void UpdateOrder(Dictionary<String, String> o);

        void UpdateUser(Dictionary<String, String> o);

        void UpdateProduct(Dictionary<String, String> o);


        void DeleteProduct(Dictionary<String, String> o);

        void DeleteUser(Dictionary<String, String> o);

        void DeleteOrder(Dictionary<String, String> o);
    }
}
