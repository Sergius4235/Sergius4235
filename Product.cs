using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("Products")]
    class Product: Model, IMap
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public float Price { get; set; }
        public string Photo { get; set; }

        public Dictionary<String, String> Mapping()
        {
            var d = new Dictionary<String, String>();
            d.Add("Id", this.Id.ToString());
            d.Add("Name", this.Name);
            d.Add("Price", this.Price.ToString());
            d.Add("Photo", this.Photo);
            d.Add("Description", this.Description);
            return d;
        }

        public void Restore(Dictionary<String, String> d)
        {
            this.Id = int.Parse(d["Id"]);
            this.Name = d["Name"];
            this.Price = float.Parse(d["Price"]);
            this.Photo = d["Photo"];
            this.Description = d["Description"];
        }
    }
}
