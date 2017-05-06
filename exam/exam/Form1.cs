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

        public Form1()
        {
            InitializeComponent();
            GetAllProduct();
            
        } 

        private void GetAllProduct()
        {
            using (ProductExamEntities db = new ProductExamEntities())
            {
                
                var au = db.ProductExam.ToList();
                FieldInfo[] fields = typeof(ProductExamEntities).GetFields(
                    BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
                string[] names = Array.ConvertAll<FieldInfo, string>(fields,
                    delegate (FieldInfo field) { return field.Name; });
                dataGridView1.DataSource = au;
                
                foreach (var a in au)
                {

                    //listBox1.Items.Add(a.Id + " " + a.Name + " " + a.producer + " " + a.Price);
                    //Console.WriteLine(a.Id + " " +a.Name + " " + a.producer + " " + a.Price);
                }
            }
        }
    }
}
