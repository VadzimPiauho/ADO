using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dz3
{
    public partial class Form2 : Form
    {
        user t;
        bool addnew;
        public Form2(user t, bool addnew, ListBox.ObjectCollection itemList)
        {
            InitializeComponent();
            this.addnew = addnew;
            this.t = t;
            if (addnew == false)
            {
                textBox1.Text = t.Login;
                textBox2.Text = t.Pass;
                textBox3.Text = t.Adres;
                textBox4.Text = t.Phone.ToString();
                if (t.Admin == true)
                {
                    checkBox1.Checked = true;
                }
                else
                {
                    checkBox1.Checked=false;
                }
                this.Text = "Редактирование пользователя";
                this.button2.Text = "Обновить";
            }
            else this.Text = "Добавление пользователя";
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Заполните все поля");
                return;
            }
            if (t == null) t = new user();
            t.Login = textBox1.Text;
            t.Pass = textBox2.Text;
            t.Adres = textBox3.Text;
            if (checkBox1.Checked == true)
            {
                t.Admin = true;
            }
            else
            {
                t.Admin = false;
            }
            try
            {
                t.Phone = Convert.ToInt32(textBox4.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Телефон указан неверно");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }
    }
}
