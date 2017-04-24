using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dz3
{
   public class user
    {
        public string Login { get; set; }

        public string Pass { get; set; }

        public string Adres { get; set; }

        public int Phone { get; set; }

        public bool Admin { get; set; }

        public user(user t)
        {
            Login = t.Login;
            Pass = t.Pass;
            Adres = t.Adres;
            Phone = t.Phone;
            Admin = t.Admin;
        }
        public user()
        {
            Login = "unknown";
            Pass = "unknown";
            Adres = "unknown";
            Phone = 0;
            Admin = false;
        }
        public user(string login, string pass, string adres, int phone,bool admin)
        {
            Login = login; Pass = pass; Adres = adres; Phone = phone; Admin = admin;
        }
        public override string ToString()
        {
            return " Логин: " + Login + " \t\tПароль: " + Pass + " \t\tАдрес: " + Adres + " \t\tТелефон: " + Phone + " \t\tАдмин: " + Admin;
            //return " Наименование: " + Name + " Описание: " + Opisanie;// + " Цена: "+Price;
        }
    }
}
