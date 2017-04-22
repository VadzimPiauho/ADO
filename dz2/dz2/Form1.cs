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
        OleDbConnection connection;
        OleDbDataAdapter da = null;
        DataSet set = null;
        OleDbCommandBuilder cmd = null;
        string cs;

        public Form1()
        {
            InitializeComponent();
            cs = ConfigurationManager.ConnectionStrings["dz2.Properties.Settings.sale_mdbConnectionString"].ConnectionString;
            connection = new OleDbConnection(cs);
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
                try
                {
                    OleDbConnection connection = new OleDbConnection(cs);
                    set = new DataSet();
                    da = new OleDbDataAdapter($"SELECT * FROM {comboBox1.Items[comboBox1.SelectedIndex].ToString()}", connection);
                    dataGridView1.DataSource = null;
                    cmd = new OleDbCommandBuilder(da);
                    da.Fill(set, comboBox1.Items[comboBox1.SelectedIndex].ToString());
                    dataGridView1.DataSource =
                    set.Tables[comboBox1.Items[comboBox1.SelectedIndex].ToString()];
                }
                catch (Exception ex)
                {

                }
                finally { }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.продажиTableAdapter.Update(this._sale_mdbDataSet.Продажи);
            da.Update(set, comboBox1.Items[comboBox1.SelectedIndex].ToString());
        }
    }
}
