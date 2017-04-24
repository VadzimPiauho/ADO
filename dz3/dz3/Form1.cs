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
    public partial class Form1 : Form
    {
        private user t = null;
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Вы не выбрали пользователя"); return;
            }
            int n = listBox1.SelectedIndex;
            t = (user)listBox1.Items[n];
            Form2 editform = new Form2(t, false);
            editform.ShowDialog();
            listBox1.Items.RemoveAt(n);
            listBox1.Items.Insert(n, t);
            listBox1.SelectedIndex = n;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            t = new user();
            Form2 addform = new Form2(t, true);
            if (addform.ShowDialog() == DialogResult.OK)
            {
                listBox1.Items.Add(t);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Вы не выбрали пользователя"); return;
            }
            int n = listBox1.SelectedIndex;
            listBox1.Items.RemoveAt(n);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
