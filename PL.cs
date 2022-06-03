using System;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using DAL;

namespace BLL
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class PLController : ApiController
    {
        private SubSystems bll = new SubSystems(new UOW());

        [HttpGet]
        [EnableCors(origins: "*", headers: "*", methods: "*")]
        public String GET(String action, String status, String search)
        {
            String response;
            switch (action)
            {
                case "GetProductsSearch":
                    response = JsonConvert.SerializeObject(this.bll.GetProductsSearch(search));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"GET request: /PL/GetProductsSearch - response 200");
                    Console.ForegroundColor = ConsoleColor.White;
                    return response;
                case "GetOrders":
                    var user = new Dictionary<String, String>
                    {
                        { "Status", status }
                    };
                    response = JsonConvert.SerializeObject(this.bll.GetOrders(user));
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"GET request: /PL/GetOrders - response 200");
                    Console.ForegroundColor = ConsoleColor.White;
                    return response;
                case "Statistics":
                    response = JsonConvert.SerializeObject(bll.Statistics());
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"GET request: /PL/Statistics - response 200");
                    Console.ForegroundColor = ConsoleColor.White;
                    return response;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine($"GET request: /PL/{action} - response 400");
                    Console.ForegroundColor = ConsoleColor.White;
                    return "Bad request";
            }
        }
        
        [HttpPost]
        public String POST([FromBody] Req Data)
        {
            String response;
            switch (Data.Action)
            {
                case "Order":
                    response = bll.Order(Data.Order(), Data.User());
                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine($"POST request: /PL/Order/{response} - response 200");
                    Console.ForegroundColor = ConsoleColor.White;
                    return response;
                case "AddProduct":
                    response = this.bll.AddProduct(Data.Product(), Data.User());
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"POST request: /PL/AddProduct/{response} - response 200");
                    Console.ForegroundColor = ConsoleColor.White;
                    return response;
                case "AddUser":
                    response = this.bll.AddUser(Data.User());
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"POST request: /PL/AddUser/{response} - response 200");
                    Console.ForegroundColor = ConsoleColor.White;
                    return response;
                case "GetProductsFilter":
                    response = JsonConvert.SerializeObject(this.bll.GetProductsFilter(Data.Product()));
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"POST request: /PL/GetProductsFilter/{response} - response 200");
                    Console.ForegroundColor = ConsoleColor.White;
                    return response;
                default:
                    response = "Bad request";
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"POST request: /PL/default/{response} - response 200");
                    Console.ForegroundColor = ConsoleColor.White;
                    return response;
            }
        }
        
        [HttpPut]
        public String PUT([FromBody] Req Data)
        {
            var response = bll.EditProduct(Data.Product(), Data.User());
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine($"PUT request: /PL/{response} - response 200");
            Console.ForegroundColor = ConsoleColor.White;
            return response;
        }

        [HttpDelete]
        public String DELETE([FromBody] Req Data)
        {
            var response = bll.DeleteOrder(Data.Order(), Data.User());
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"DELETE request: /PL/{response} - response 200");
            Console.ForegroundColor = ConsoleColor.Red;
            return response;
        }
    }
}
