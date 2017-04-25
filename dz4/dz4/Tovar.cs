using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz4
{
    public class Tovar
    {
        public string Name { get; set; }
        public Tovar(Tovar t)
        {
            Name = t.Name;
        }
        public Tovar()
        {
            Name = "unknown";
        }
        public Tovar(string login)
        {
            Name = login;
        }
        public override string ToString()
        {
            return /*" Товар: " +*/ Name;
        }
    }
}
