using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    interface IMap
    {
        Dictionary<String, String> Mapping();

        void Restore(Dictionary<String, String> d);
    }
}
