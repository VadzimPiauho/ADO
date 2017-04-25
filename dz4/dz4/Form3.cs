using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dz4
{
    public partial class Form3 : Form
    {
        user u;
        bool addnew;

        public Form3(user u, bool addnew)
        {
            InitializeComponent();
            this.addnew = addnew;
            
                this.u = u;
                if (addnew == false)
                {
                    textBox1.Text = u.Name;
                    this.Text = "Редактирование продавца";
                    this.button2.Text = "Обновить";
                }
                else this.Text = "Добавление продавца";
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "")
            {
                MessageBox.Show("Заполните поле");
                return;
            }
            if (u == null) u = new user();
            u.Name = textBox1.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
