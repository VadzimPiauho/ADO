using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exam
{
    public partial class Form2 : Form
    {
        ProductExam t;
        private bool addnew;
        public Form2(ProductExam t, bool addnew)
        {
            InitializeComponent();
            this.addnew = addnew;
            this.t = t;
            if (addnew == false)
            {
                textBox2.Text = t.Name;
                textBox3.Text = t.producer;
                textBox4.Text = Convert.ToString(t.Price);
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
            if (/*textBox1.Text == "" ||*/ textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "")
            {
                MessageBox.Show("Заполните поле");
                return;
            }
            if (t == null) t = new ProductExam();
            //try
            //{
            //    t.Id = Int32.Parse(textBox1.Text);
            //}
            //catch (Exception)
            //{
            //    MessageBox.Show("Id указан неверно");
            //    return;
            //}
            t.Name = textBox2.Text;
            t.producer = textBox3.Text;
            try
            {
                t.Price = Convert.ToDecimal(textBox4.Text);
            }
            catch (Exception)
            {
                MessageBox.Show("Цена указана неверно");
                return;
            }
            this.DialogResult = DialogResult.OK;
        }
    }
}
