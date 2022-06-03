using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UOW: IUOW
    {
        private Repository<User> Users;
        private Repository<Product> Products;
        private Repository<Order> Orders;

        public UOW()
        {
            this.Users = new Repository<User>();
            this.Products = new Repository<Product>();
            this.Orders = new Repository<Order>();
            //this.Init();
        }

        private void Init()
        {
            var order = new Dictionary<String, String>();
            order.Add("Id", "0");
            order.Add("Time", "13:15");
            order.Add("UserId", "3");
            order.Add("ProductId", "6");
            order.Add("Price", "100");
            this.CreateOrder(order);

            var user = new Dictionary<String, String>();
            user.Add("Id", "0");
            user.Add("Status", "admin");
            user.Add("Name", "vovan");
            user.Add("LastName", "last");
            user.Add("Avatar", "ava");
            this.CreateUser(user);

            var product = new Dictionary<String, String>();
            product.Add("Id", "0");
            product.Add("Name", "milk");
            product.Add("Description", "food");
            product.Add("Photo", "none");
            product.Add("Price", "100");
            this.CreateProduct(product);
            /*
            this.Dishes.InsertDish(new Dish() { DishId = 1, Name = "Burger", OrderId = 0 });
            this.Dishes.InsertDish(new Dish() { DishId = 2, Name = "Pancake", OrderId = 0 });
            this.Dishes.InsertDish(new Dish() { DishId = 3, Name = "Tea", OrderId = 0 });
            this.Dishes.InsertDish(new Dish() { DishId = 4, Name = "Pasta", OrderId = 0 });
            this.Dishes.InsertDish(new Dish() { DishId = 5, Name = "Teftel", OrderId = 0 });

            this.SeasonDishes.InsertDish(new SeasonDish() { DishId = 0, Name = "Burger", Price = 35, Details = "Beef and daycon", Season = "Monday", Image = "https://images.unsplash.com/photo-1550547660-d9450f859349?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8Zm9vZCUyMHBob3RvZ3JhcGh5fGVufDB8fDB8fA%3D%3D&auto=format&fit=crop&w=500&q=60" });
            this.SeasonDishes.InsertDish(new SeasonDish() { DishId = 1, Name = "Pancake", Price = 25, Details = "Maple syrop", Season = "Tuesday", Image = "https://images.unsplash.com/photo-1554520735-0a6b8b6ce8b7?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8M3x8Zm9vZCUyMHBob3RvZ3JhcGh5fGVufDB8fDB8fA%3D%3D&auto=format&fit=crop&w=500&q=60" });
            this.SeasonDishes.InsertDish(new SeasonDish() { DishId = 2, Name = "Tea", Price = 10, Details = "Lime and ice", Season = "Friday", Image = "https://images.unsplash.com/photo-1556679343-c7306c1976bc?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NHx8Zm9vZCUyMHBob3RvZ3JhcGh5fGVufDB8fDB8fA%3D%3D&auto=format&fit=crop&w=500&q=60" });
            this.SeasonDishes.InsertDish(new SeasonDish() { DishId = 3, Name = "Pasta", Price = 25, Details = "Basil & parmezan", Season = "Sunday", Image = "https://images.unsplash.com/photo-1531089073319-17596b946d42?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Nnx8Zm9vZCUyMHBob3RvZ3JhcGh5fGVufDB8fDB8fA%3D%3D&auto=format&fit=crop&w=500&q=60" });
            this.SeasonDishes.InsertDish(new SeasonDish() { DishId = 4, Name = "Teftel", Price = 45, Details = "Tomato & cheese", Season = "Sunday", Image = "https://images.unsplash.com/photo-1515516969-d4008cc6241a?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTB8fGZvb2QlMjBwaG90b2dyYXBoeXxlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60" });
            this.SeasonDishes.InsertDish(new SeasonDish() { DishId = 5, Name = "Cruasan", Price = 15, Details = "Avocado & tomato", Season = "Sunday", Image = "https://images.unsplash.com/photo-1603046891744-1f76eb10aec7?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTZ8fGZvb2QlMjBwaG90b2dyYXBoeXxlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60" });
            this.SeasonDishes.InsertDish(new SeasonDish() { DishId = 6, Name = "Potato", Price = 30, Details = "Mayoran & butter", Season = "Friday", Image = "https://images.unsplash.com/photo-1552845683-cfefc701e423?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MzF8fGZvb2QlMjBwaG90b2dyYXBoeXxlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60" });
            this.SeasonDishes.InsertDish(new SeasonDish() { DishId = 7, Name = "Cock", Price = 25, Details = "Rosemary", Season = "Monday", Image = "https://images.unsplash.com/photo-1592483648228-b35146a4330c?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NDV8fGZvb2QlMjBwaG90b2dyYXBoeXxlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60" });
            this.SeasonDishes.InsertDish(new SeasonDish() { DishId = 8, Name = "Ramen", Price = 55, Details = "Egg an beef", Season = "Monday", Image = "https://images.unsplash.com/photo-1552611052-33e04de081de?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NTd8fGZvb2QlMjBwaG90b2dyYXBoeXxlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60" });
            this.SeasonDishes.InsertDish(new SeasonDish() { DishId = 9, Name = "Cookies", Price = 15, Details = "Chocolate", Season = "Monday", Image = "https://images.unsplash.com/photo-1558961363-fa8fdf82db35?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NjB8fGZvb2QlMjBwaG90b2dyYXBoeXxlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60" });
            this.SeasonDishes.InsertDish(new SeasonDish() { DishId = 10, Name = "Tortilla", Price = 20, Details = "Avocado & corn", Season = "Tuesday", Image = "https://images.unsplash.com/photo-1588556008426-af415581d44b?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NzR8fGZvb2QlMjBwaG90b2dyYXBoeXxlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60" });

            this.TypeDishes.InsertDish(new TypeDish() { DishId = 0, Name = "Burger", Price = 35, Details = "Beef and daycon", Type = "Second", Image = "https://images.unsplash.com/photo-1550547660-d9450f859349?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Mnx8Zm9vZCUyMHBob3RvZ3JhcGh5fGVufDB8fDB8fA%3D%3D&auto=format&fit=crop&w=500&q=60" });
            this.TypeDishes.InsertDish(new TypeDish() { DishId = 1, Name = "Pancake", Price = 25, Details = "Maple syrop", Type = "Desert", Image = "https://images.unsplash.com/photo-1554520735-0a6b8b6ce8b7?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8M3x8Zm9vZCUyMHBob3RvZ3JhcGh5fGVufDB8fDB8fA%3D%3D&auto=format&fit=crop&w=500&q=60" });
            this.TypeDishes.InsertDish(new TypeDish() { DishId = 2, Name = "Tea", Price = 10, Details = "Lime and ice", Type = "Desert", Image = "https://images.unsplash.com/photo-1556679343-c7306c1976bc?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NHx8Zm9vZCUyMHBob3RvZ3JhcGh5fGVufDB8fDB8fA%3D%3D&auto=format&fit=crop&w=500&q=60" });
            this.TypeDishes.InsertDish(new TypeDish() { DishId = 3, Name = "Pasta", Price = 25, Details = "Basil & parmezan", Type = "Second", Image = "https://images.unsplash.com/photo-1531089073319-17596b946d42?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8Nnx8Zm9vZCUyMHBob3RvZ3JhcGh5fGVufDB8fDB8fA%3D%3D&auto=format&fit=crop&w=500&q=60" });
            this.TypeDishes.InsertDish(new TypeDish() { DishId = 4, Name = "Teftel", Price = 45, Details = "Tomato & cheese", Type = "Second", Image = "https://images.unsplash.com/photo-1515516969-d4008cc6241a?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTB8fGZvb2QlMjBwaG90b2dyYXBoeXxlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60" });
            this.TypeDishes.InsertDish(new TypeDish() { DishId = 5, Name = "Cruasan", Price = 15, Details = "Avocado & tomato", Type = "Desert", Image = "https://images.unsplash.com/photo-1603046891744-1f76eb10aec7?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MTZ8fGZvb2QlMjBwaG90b2dyYXBoeXxlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60" });
            this.TypeDishes.InsertDish(new TypeDish() { DishId = 6, Name = "Potato", Price = 30, Details = "Mayoran & butter", Type = "Second", Image = "https://images.unsplash.com/photo-1552845683-cfefc701e423?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8MzF8fGZvb2QlMjBwaG90b2dyYXBoeXxlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60" });
            this.TypeDishes.InsertDish(new TypeDish() { DishId = 7, Name = "Cock", Price = 25, Details = "Rosemary", Type = "Desert", Image = "https://images.unsplash.com/photo-1592483648228-b35146a4330c?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NDV8fGZvb2QlMjBwaG90b2dyYXBoeXxlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60" });
            this.TypeDishes.InsertDish(new TypeDish() { DishId = 8, Name = "Ramen", Price = 55, Details = "Egg an beef", Type = "First", Image = "https://images.unsplash.com/photo-1552611052-33e04de081de?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NTd8fGZvb2QlMjBwaG90b2dyYXBoeXxlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60" });
            this.TypeDishes.InsertDish(new TypeDish() { DishId = 9, Name = "Cookies", Price = 15, Details = "Chocolate", Type = "Desert", Image = "https://images.unsplash.com/photo-1558961363-fa8fdf82db35?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NjB8fGZvb2QlMjBwaG90b2dyYXBoeXxlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60" });
            this.TypeDishes.InsertDish(new TypeDish() { DishId = 10, Name = "Tortilla", Price = 20, Details = "Avocado & corn", Type = "Second", Image = "https://images.unsplash.com/photo-1588556008426-af415581d44b?ixlib=rb-1.2.1&ixid=MnwxMjA3fDB8MHxzZWFyY2h8NzR8fGZvb2QlMjBwaG90b2dyYXBoeXxlbnwwfHwwfHw%3D&auto=format&fit=crop&w=500&q=60" });
            */
        }

        public Dictionary<String, String> CreateOrder(Dictionary<String, String> order)
        {
            var o = new Order();
            o.Restore(order);
            this.Orders.Create(o);
            return o.Mapping();
        }

        public Dictionary<String, String> CreateUser(Dictionary<String, String> user)
        {
            var o = new User();
            o.Restore(user);
            this.Users.Create(o);
            return o.Mapping();
        }

        public Dictionary<String, String> CreateProduct(Dictionary<String, String> product)
        {
            var o = new Product();
            o.Restore(product);
            this.Products.Create(o);
            return o.Mapping();
        }


        public Dictionary<String, String>[] ReadAllOrders()
        {
            var dict = new List<Dictionary<String, String>>();
            foreach (var i in this.Orders.GetAll())
            {
                dict.Add(i.Mapping());
            }
            return dict.ToArray();
        }

        public Dictionary<String, String>[] ReadAllUsers()
        {
            var dict = new List<Dictionary<String, String>>();
            foreach (var i in this.Users.GetAll())
            {
                dict.Add(i.Mapping());
            }
            return dict.ToArray();
        }

        public Dictionary<String, String>[] ReadAllProducts()
        {
            var dict = new List<Dictionary<String, String>>();
            foreach (var i in this.Products.GetAll())
            {
                dict.Add(i.Mapping());
            }
            return dict.ToArray();
        }


        public Dictionary<String, String> ReadOrder(int Id)
        {
            return this.Orders.Read(Id).Mapping();
        }

        public Dictionary<String, String> ReadUser(int Id)
        {
            return this.Users.Read(Id).Mapping();
        }

        public Dictionary<String, String> ReadProduct(int Id)
        {
            return this.Products.Read(Id).Mapping();
        }


        public void UpdateOrder(Dictionary<String, String> o)
        {
            var d = new Order();
            d.Restore(o);
            this.Orders.Update(d);
        }

        public void UpdateUser(Dictionary<String, String> o)
        {
            var d = new User();
            d.Restore(o);
            this.Users.Update(d);
        }

        public void UpdateProduct(Dictionary<String, String> o)
        {
            var d = new Product();
            d.Restore(o);
            this.Products.Update(d);
        }


        public void DeleteProduct(Dictionary<String, String> o)
        {
            var d = new Product();
            d.Restore(o);
            this.Products.Delete(d);
        }

        public void DeleteUser(Dictionary<String, String> o)
        {
            var d = new User();
            d.Restore(o);
            this.Users.Delete(d);
        }

        public void DeleteOrder(Dictionary<String, String> o)
        {
            var d = new Order();
            d.Restore(o);
            this.Orders.Delete(d);
        }

    }
}
