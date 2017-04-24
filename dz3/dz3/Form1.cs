using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
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
        private ListBox.ObjectCollection itemList;

        private SqlConnection conn = null;
        SqlDataAdapter da = null;
        DataSet set = null;
        SqlCommandBuilder cmd = null;
        string cs = "";
        private SqlDataReader reader;
        //private DataTable table;
        private SqlCommand comm;

        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection();
            cs = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
            conn.ConnectionString = cs;

        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Вы не выбрали пользователя"); return;
            }
            int n = listBox1.SelectedIndex;
            t = (user)listBox1.Items[n];
            itemList = listBox1.Items;
            Form2 editform = new Form2(t, false, itemList);
            editform.ShowDialog();
            listBox1.Items.RemoveAt(n);
            listBox1.Items.Insert(n, t);
            listBox1.SelectedIndex = n;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            t = new user();
            Form2 addform = new Form2(t, true, itemList);
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

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(cs);
                string sql = "SELECT * FROM Personal";

                comm = new SqlCommand();
                comm.CommandText = sql;
                comm.Connection = conn;
                conn.Open();
                reader = comm.ExecuteReader();

                int line = 0;
                do
                {
                    while (reader.Read())
                    {
                        //if (line == 0)
                        //{
                        //    for (int i = 0; i < reader.FieldCount; i++)
                        //    {
                        //        listBox1.Items.Add(reader.GetName(i));
                        //    }
                        //    line++;
                        //}
                        
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            listBox1.Items.Add(reader[i]);
                            
                        }
                        
                    }
                } while (reader.NextResult());

                set = new DataSet();
                da = new SqlDataAdapter(sql, conn);
                dataGridView1.DataSource = null;
                cmd = new SqlCommandBuilder(da);
                da.Fill(set, "Personal");
                dataGridView1.DataSource = set.Tables["Personal"];



            }
            catch (Exception ex)
            {
            }
            finally
            {
                // Close the connection
                if (conn != null)
                {
                    conn.Close();
                }
                if (reader != null)
                {
                    reader.Close();
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            da.Update(set, "Personal");
        }

        
    }
}
