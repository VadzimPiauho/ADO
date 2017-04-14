using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;
using System.Data.OleDb;

namespace dz2
{
    public partial class Form1 : Form
    {
        DataTable dt;
        public Form1()
        {
            InitializeComponent();
            string cs = ConfigurationManager.ConnectionStrings["dz2.Properties.Settings.sale_mdbConnectionString"].ConnectionString;
            OleDbConnection connection = new OleDbConnection(cs);
            connection.Open();
            dt = connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, new object[] { null, null, null, "TABLE" });
            foreach (DataRow item in dt.Rows)
            {
                comboBox1.Items.Add((string)item["TABLE_NAME"]);
            }
            connection.Close();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // TODO: This line of code loads data into the '_sale_mdbDataSet.Продажи' table. You can move, or remove it, as needed.
            this.продажиTableAdapter.Fill(this._sale_mdbDataSet.Продажи);
            // TODO: This line of code loads data into the '_sale_mdbDataSet.Продавцы' table. You can move, or remove it, as needed.
            this.продавцыTableAdapter.Fill(this._sale_mdbDataSet.Продавцы);
            // TODO: This line of code loads data into the '_sale_mdbDataSet.Покупатели' table. You can move, or remove it, as needed.
            this.покупателиTableAdapter.Fill(this._sale_mdbDataSet.Покупатели);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex > -1)
            {
                if (comboBox1.SelectedIndex==0)
                {
                    var x = dataGridView1.DataSource;
                    this.покупателиTableAdapter.Fill(this._sale_mdbDataSet.Покупатели);
                }
                if (comboBox1.SelectedIndex == 1)
                {
                    this.продавцыTableAdapter.Fill(this._sale_mdbDataSet.Продавцы);
                }
                if (comboBox1.SelectedIndex == 2)
                {
                    this.продажиTableAdapter.Fill(this._sale_mdbDataSet.Продажи);
                }
            }

        }
    }
}
