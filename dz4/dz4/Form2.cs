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
    public partial class Form2 : Form
    {
        Tovar t;
        bool addnew;
        public Form2(Tovar t, bool addnew)
        {
            InitializeComponent();
            this.addnew = addnew;
            this.t = t;
            if (addnew == false)
            {
                textBox1.Text = t.Name;
                this.Text = "Редактирование товара";
                this.button2.Text = "Обновить";
            }
            else this.Text = "Добавление товара";
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
            if (t == null) t = new Tovar();
            t.Name = textBox1.Text;
            this.DialogResult = DialogResult.OK;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }
    }
}
