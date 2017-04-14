using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace dz2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the '_sale_mdbDataSet.Продавцы' table. You can move, or remove it, as needed.
            this.продавцыTableAdapter.Fill(this._sale_mdbDataSet.Продавцы);
            // TODO: This line of code loads data into the '_sale_mdbDataSet.Покупатели' table. You can move, or remove it, as needed.
            this.покупателиTableAdapter.Fill(this._sale_mdbDataSet.Покупатели);

        }
    }
}
