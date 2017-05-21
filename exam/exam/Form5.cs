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
    public partial class Form5 : Form
    {
        private ProductExamEntities2 db;
        private Attribute attribute;
        private Product product;
        private Value value;
        TextBox[] tb;
        private int countTexbox=0;

        public Form5(ProductExamEntities2 db, Product product)
        {
            InitializeComponent();
            int xLabel = 16;
            int yItem = 64;
            int xTexbox = 124;
            this.product = product;
            this.db = db;
            textBox2.Text = product.Name;
            textBox3.Text = product.Producer;
           
            var valueTable = db.Value.Where(x => x.IdProduct == product.Id).ToList();
            tb = new TextBox[valueTable.Count];
            foreach (var VARIABLE in valueTable)
            {
                this.Controls.Add(new Label(){Text = VARIABLE.Attribute.NameAtt, Location = new Point(xLabel,yItem)});
                tb[countTexbox] = new TextBox() { Text = VARIABLE.Value1, Location = new Point(xTexbox, yItem), Size = new Size(196, 20) };
                this.Controls.Add(tb[countTexbox]);
                yItem += 24;
                countTexbox++;
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            countTexbox = 0;
            var valueTable = db.Value.Where(x => x.IdProduct == product.Id).ToList();
            foreach (var VARIABLE in valueTable)
            {
                VARIABLE.Value1 = tb[countTexbox].Text;
                countTexbox++;
            }
            db.SaveChanges();
        }
    }
}
