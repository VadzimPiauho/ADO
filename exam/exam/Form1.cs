using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace exam
{
    public partial class Form1 : Form
    {
        ListView list = new ListView();
        private Product t = null;
        private ProductExamEntities2 db = new ProductExamEntities2();

        public Form1()
        {
            InitializeComponent();
            GetAllProduct();
        }

        private void GetAllProduct()
        {
            var au1 = db.Value.ToList();
            var au = db.Product.ToList();
            dataGridView1.DataSource = au1;
            foreach (var VARIABLE in au)
            {
                listBox1.Items.Add(VARIABLE.Name + "\t" + VARIABLE.Price);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Column", "Test");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            t = new Product();
            var tm = db.Product.Max(x => x.Id);
            t.Id = tm + 1;
            Form2 addform = new Form2(t, true);
            if (addform.ShowDialog() == DialogResult.OK)
            {
                var au = db.Product;
                au.Add(t);
                db.SaveChanges();
                listBox1.Items.Clear();
                GetAllProduct();
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Вы не выбрали товар"); return;
            }
            t = new Product();
            int n = listBox1.SelectedIndex;
            var au = db.Product.OrderBy(x => x.Id);
            foreach (var VARIABLE in au.Skip(n))
            {
                t = VARIABLE;
                break;
            }
            Form2 editform = new Form2(t, false);
            editform.ShowDialog();
            listBox1.Items.RemoveAt(n);
            listBox1.Items.Insert(n, t);
            listBox1.SelectedIndex = n;
            db.SaveChanges();
            listBox1.Items.Clear();
            GetAllProduct();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 attForm3 = new Form3(db);
            attForm3.ShowDialog();
        }
    }
}
