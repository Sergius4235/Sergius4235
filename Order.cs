using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("Orders")]
    class Order: Model, IMap
    {
        public string Time { get; set; }
        public int UserId { get; set; }
        public int ProductId { get; set; }
        public float Price { get; set; }

        public Dictionary<String, String> Mapping()
        {
            var d = new Dictionary<String, String>();
            d.Add("Id", this.Id.ToString());
            d.Add("UserId", this.UserId.ToString());
            d.Add("ProductId", this.ProductId.ToString());
            d.Add("Price", this.Price.ToString());
            d.Add("Time", this.Time);
            return d;
        }

        public void Restore(Dictionary<String, String> d)
        {
            this.UserId = int.Parse(d["UserId"]);
            this.ProductId = int.Parse(d["ProductId"]);
            this.Time = d["Time"];
            this.Price = float.Parse(d["Price"]);
        }
    }
}
