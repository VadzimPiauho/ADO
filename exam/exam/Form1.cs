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
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'productExamDataSet.ProductExam' table. You can move, or remove it, as needed.
            this.productExamTableAdapter.Fill(this.productExamDataSet.ProductExam);
        }



        private void button1_Click(object sender, EventArgs e)
        {
            db.SaveChanges();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dataGridView1.Columns.Add("Column", "Test");
        }
    }
}
