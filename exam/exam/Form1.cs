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
        private ProductExam t = null;
        private ProductExamEntities db = new ProductExamEntities();

        public Form1()
        {
            InitializeComponent();
            GetAllProduct();

        }

        private void GetAllProduct()
        {
            //var au = db.ProductExam.;
            var au = db.ProductExam.ToList();
            dataGridView1.DataSource = au;
            foreach (var VARIABLE in au)
            {
                listBox1.Items.Add(VARIABLE.Name + "\t" + VARIABLE.Price);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Column", "Test");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            t = new ProductExam();
            var tm = db.ProductExam.Max(x => x.Id);
            t.Id = tm + 1;
            Form2 addform = new Form2(t, true);
            if (addform.ShowDialog() == DialogResult.OK)
            {
                var au = db.ProductExam;
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
            t = new ProductExam();
            int n = listBox1.SelectedIndex;
            var au = db.ProductExam.OrderBy(x=>x.Id);
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
    }
}
