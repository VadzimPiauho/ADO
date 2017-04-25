using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz4
{
    public class user
    {
        public string Name { get; set; }
        public user(user t)
        {
            Name = t.Name;
        }
        public user()
        {
            Name = "unknown";
        }
        public user(string login)
        {
            Name = login;
        }
        public override string ToString()
        {
            return /*" Продавец: " +*/ Name;
        }
    }
}
