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
        SqlConnectionStringBuilder builder =
           new SqlConnectionStringBuilder(GetConnectionString());

        private static string GetConnectionString()
        {
            return "Data Source=(localdb)\\MSSQLLocalDB;" +
                "Initial Catalog=Users;" +
                "Integrated Security=True;Connect Timeout=30;" +
                "Encrypt=False;TrustServerCertificate=True;" +
                "ApplicationIntent=ReadWrite;" +
                "MultiSubnetFailover=False";
        }

        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection();
            //cs = ConfigurationManager.ConnectionStrings["MyConnString"].ConnectionString;
            //conn.ConnectionString = cs;
            
            conn.ConnectionString = builder.ConnectionString;

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
            listBox1.Items.Clear();
            try
            {
                SqlConnection conn = new SqlConnection(builder.ConnectionString);
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
                        t = new user();
                        for (int i = 0; i < reader.FieldCount; i++)
                        {
                            t.Login = Convert.ToString(reader[1]);
                            t.Pass = Convert.ToString(reader[2]);
                            t.Adres = Convert.ToString(reader[3]);
                            t.Phone = Convert.ToInt32(reader[4]);
                            t.Admin = Convert.ToBoolean(reader[5]);
                        }
                        listBox1.Items.Add(t);
                    }
                } while (reader.NextResult());
                reader.Close();

                set = new DataSet();
                da = new SqlDataAdapter(sql, conn);
                dataGridView1.DataSource = null;
                cmd = new SqlCommandBuilder(da);
                da.Fill(set, "Personal");
                DataTable dt1 = set.Tables[0];
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
