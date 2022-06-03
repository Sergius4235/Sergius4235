using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    [Table("Users")]
    class User: Model, IMap
    {
        public string Status { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Avatar { get; set; }

        public Dictionary<String, String> Mapping()
        {
            var d = new Dictionary<String, String>();
            d.Add("Status", this.Status);
            d.Add("Name", this.Name);
            d.Add("LastName", this.LastName);
            d.Add("Avatar", this.Avatar);
            d.Add("Id", this.Id.ToString());
            return d;
        }

        public void Restore(Dictionary<String, String> d)
        {
            this.Status = d["Status"];
            this.Name = d["Name"];
            this.LastName = d["LastName"];
            this.Avatar = d["Avatar"];
            this.Id = int.Parse(d["Id"]);
        }
    }
}
