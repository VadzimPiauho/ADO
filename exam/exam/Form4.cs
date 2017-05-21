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
    public partial class Form4 : Form
    {
        Attribute t;
        private bool addnew;
        public Form4(Attribute t, bool addnew)
        {
            InitializeComponent();
            this.addnew = addnew;
            this.t = t;
            if (addnew == false)
            {
                textBox2.Text = t.NameAtt;

                this.Text = "Редактирование атрибута";
                this.button2.Text = "Обновить";
            }
            else this.Text = "Добавление атрибута";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text == "")
            {
                MessageBox.Show("Заполните поле");
                return;
            }
            if (t == null) t = new Attribute();
            t.NameAtt = textBox2.Text;
            this.DialogResult = DialogResult.OK;
        }
    }
}
