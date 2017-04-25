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
    public partial class Form4 : Form
    {
        buyer b;
        bool addnew;

        public Form4(buyer b, bool addnew)
        {
            InitializeComponent();
            this.addnew = addnew;
           
                this.b = b;
                if (addnew == false)
                {
                    textBox1.Text = b.Name;
                    this.Text = "Редактирование покупателя";
                    this.button2.Text = "Обновить";
                }
                else this.Text = "Добавление покупателя";
            
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
            if (b == null) b = new buyer();
            b.Name = textBox1.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
