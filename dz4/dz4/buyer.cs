using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz4
{
    public class buyer
    {
        public string Name { get; set; }
        public buyer(buyer t)
        {
            Name = t.Name;
        }
        public buyer()
        {
            Name = "unknown";
        }
        public buyer(string login)
        {
            Name = login;
        }
        public override string ToString()
        {
            return /*" Покупатель: " +*/ Name;
        }
    }
}
