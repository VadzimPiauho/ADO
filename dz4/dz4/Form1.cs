using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.XPath;

namespace dz4
{
    public partial class Form1 : Form
    {
        Tovar t = null;
        user u = null;
        buyer b = null;
        string TovarFileXml = "Tovar.xml";
        string userFileXml = "user.xml";
        string buyerFileXml = "buyer.xml";


        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            t = new Tovar();
            Form2 addform = new Form2(t, true);
            if (addform.ShowDialog() == DialogResult.OK)
            {
                comboBox2.Items.Add(t);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            b = new buyer();
            Form4 addform = new Form4(b, true);
            if (addform.ShowDialog() == DialogResult.OK)
            {
                comboBox3.Items.Add(b);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            u = new user();
            Form3 addform = new Form3(u, true);
            if (addform.ShowDialog() == DialogResult.OK)
            {
                comboBox1.Items.Add(u);
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Вы не выбрали продавца"); return;
            }
            int n = comboBox1.SelectedIndex;
            u = (user)comboBox1.Items[n];
            Form3 editform = new Form3(u, false);
            editform.ShowDialog();
            comboBox1.Items.RemoveAt(n);
            comboBox1.Items.Insert(n, u);
            comboBox1.SelectedIndex = n;
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Вы не выбрали товар"); return;
            }
            int n = comboBox2.SelectedIndex;
            t = (Tovar)comboBox2.Items[n];
            Form2 editform = new Form2(t, false);
            editform.ShowDialog();
            comboBox2.Items.RemoveAt(n);
            comboBox2.Items.Insert(n, t);
            comboBox2.SelectedIndex = n;
        }

        private void button8_Click(object sender, EventArgs e)
        {
            if (comboBox3.SelectedIndex == -1)
            {
                MessageBox.Show("Вы не выбрали покупателя"); return;
            }
            int n = comboBox3.SelectedIndex;
            b = (buyer)comboBox3.Items[n];
            Form4 editform = new Form4(b, false);
            editform.ShowDialog();
            comboBox3.Items.RemoveAt(n);
            comboBox3.Items.Insert(n, b);
            comboBox3.SelectedIndex = n;
        }

        private void button9_Click(object sender, EventArgs e)
        {
            if (comboBox2.SelectedIndex == -1)
            {
                MessageBox.Show("Вы не выбрали товар"); return;
            }
            t = (Tovar)comboBox2.Items[comboBox2.SelectedIndex];
            Tovar t2 = new Tovar(t);
            listBox1.Items.Add(t2);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Вы не выбрали товар"); return;
            }
            int n = listBox1.SelectedIndex;
            listBox1.Items.RemoveAt(n);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (!File.Exists(TovarFileXml))
            {
                MessageBox.Show("Файла товаров не существует.Файл успешно создан в каталоге Debug", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FileStream fs1 = File.Create(TovarFileXml);
                fs1.Close();
                xml_ChangedTovar(sender, e);
            }
            else
            {
                var res = MessageBox.Show("Заменить существующий файл товаров?", "Инфо", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == res)
                {
                    xml_ChangedTovar(sender, e);
                }
            }
            /////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (!File.Exists(userFileXml))
            {
                MessageBox.Show("Файла продавцов не существует.Файл успешно создан в каталоге Debug", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FileStream fs1 = File.Create(userFileXml);
                fs1.Close();
                xml_ChangedUser(sender, e);
            }
            else
            {
                var res = MessageBox.Show("Заменить существующий файл продавцов?", "Инфо", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == res)
                {
                    xml_ChangedUser(sender, e);
                }
            }
            ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////
            if (!File.Exists(buyerFileXml))
            {
                MessageBox.Show("Файла покупателей не существует.Файл успешно создан в каталоге Debug", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FileStream fs1 = File.Create(buyerFileXml);
                fs1.Close();
                xml_ChangedBuyer(sender, e);
            }
            else
            {
                var res = MessageBox.Show("Заменить существующий файл покупателей?", "Инфо", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == res)
                {
                    xml_ChangedBuyer(sender, e);
                }
            }
        }

        private void xml_ChangedBuyer(object sender, EventArgs p1)
        {
            if (comboBox3.Items.Count != 0)
            {
                XmlTextWriter buyer = null;
                try
                {
                    buyer = new XmlTextWriter(buyerFileXml, System.Text.Encoding.Unicode);
                    buyer.Formatting = Formatting.Indented;
                    buyer.WriteStartDocument();
                    buyer.WriteStartElement("buyerList");
                    for (var i = 0; i < comboBox3.Items.Count; i++)
                    {
                        string str = Convert.ToString(comboBox3.Items[i]);

                        buyer.WriteStartElement($"buyer");
                        buyer.WriteElementString($"buyer{i}", Convert.ToString(comboBox3.Items[i]));
                        buyer.WriteEndElement();
                    }
                    buyer.WriteEndElement();
                }
                finally
                {
                    if (buyer != null)
                        buyer.Close();
                    MessageBox.Show("Данные внесены в файл", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("combobox - пуст, файл не обновлен", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void xml_ChangedUser(object sender, EventArgs p1)
        {
            if (comboBox1.Items.Count != 0)
            {
                XmlTextWriter user = null;
                try
                {
                    user = new XmlTextWriter(userFileXml, System.Text.Encoding.Unicode);
                    user.Formatting = Formatting.Indented;
                    user.WriteStartDocument();
                    user.WriteStartElement("userList");
                    for (var i = 0; i < comboBox1.Items.Count; i++)
                    {
                        string str = Convert.ToString(comboBox1.Items[i]);

                        user.WriteStartElement($"user");
                        user.WriteElementString($"user{i}", Convert.ToString(comboBox1.Items[i]));
                        user.WriteEndElement();
                    }
                    user.WriteEndElement();
                }
                finally
                {
                    if (user != null)
                        user.Close();
                    MessageBox.Show("Данные внесены в файл", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("combobox - пуст, файл не обновлен", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void xml_ChangedTovar(object sender, EventArgs p1)
        {
            if (comboBox2.Items.Count != 0)
            {
                XmlTextWriter tovar = null;
                try
                {
                    tovar = new XmlTextWriter(TovarFileXml, System.Text.Encoding.Unicode);
                    tovar.Formatting = Formatting.Indented;
                    tovar.WriteStartDocument();
                    tovar.WriteStartElement("tovarList");
                    for (var i = 0; i < comboBox2.Items.Count; i++)
                    {
                        string str = Convert.ToString(comboBox2.Items[i]);

                        tovar.WriteStartElement($"tovar");
                        tovar.WriteElementString($"tovar{i}", Convert.ToString(comboBox2.Items[i]));
                        tovar.WriteEndElement();
                    }
                    tovar.WriteEndElement();
                }
                finally
                {
                    if (tovar != null)
                        tovar.Close();
                    MessageBox.Show("Данные внесены в файл", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("combobox - пуст, файл не обновлен", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            comboBox2.Items.Clear();
            comboBox3.Items.Clear();


            if (!File.Exists(TovarFileXml))
            {
                MessageBox.Show("Файла товаров не существует", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                using (StreamReader sr = File.OpenText(TovarFileXml))
                {
                    var i = 0;
                    var fi = new FileInfo(TovarFileXml);
                    if (fi.Length == 0)
                    {
                        MessageBox.Show("Файл товаров пуст.", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XPathDocument doc = new XPathDocument(TovarFileXml);
                        XPathNavigator nav = doc.CreateNavigator();
                        XPathNodeIterator iterator = nav.Select("/tovarList/tovar");
                        int x = iterator.Count;
                        
                        while (iterator.MoveNext())
                        {
                            XPathNodeIterator it = iterator.Current.Select($"tovar{i}");
                            i++;
                            it.MoveNext();
                            t = new Tovar();
                            t.Name = it.Current.Value;
                            comboBox2.Items.Add(t);
                        }
                    }
                }
            }
            if (!File.Exists(userFileXml))
            {
                MessageBox.Show("Файла продавцов не существует", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                using (StreamReader sr = File.OpenText(userFileXml))
                {
                    var i = 0;
                    var fi = new FileInfo(userFileXml);
                    if (fi.Length == 0)
                    {
                        MessageBox.Show("Файл продавцов пуст.", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XPathDocument doc = new XPathDocument(userFileXml);
                        XPathNavigator nav = doc.CreateNavigator();
                        XPathNodeIterator iterator = nav.Select("/userList/user");
                        int x = iterator.Count;

                        while (iterator.MoveNext())
                        {
                            XPathNodeIterator it = iterator.Current.Select($"user{i}");
                            i++;
                            it.MoveNext();
                            u = new user();
                            u.Name = it.Current.Value;
                            comboBox1.Items.Add(u);
                        }
                    }
                }
            }
            if (!File.Exists(buyerFileXml))
            {
                MessageBox.Show("Файла покупателей не существует", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                using (StreamReader sr = File.OpenText(buyerFileXml))
                {
                    var i = 0;
                    var fi = new FileInfo(buyerFileXml);
                    if (fi.Length == 0)
                    {
                        MessageBox.Show("Файл покупателей пуст.", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        XPathDocument doc = new XPathDocument(buyerFileXml);
                        XPathNavigator nav = doc.CreateNavigator();
                        XPathNodeIterator iterator = nav.Select("/buyerList/buyer");
                        int x = iterator.Count;

                        while (iterator.MoveNext())
                        {
                            XPathNodeIterator it = iterator.Current.Select($"buyer{i}");
                            i++;
                            it.MoveNext();
                            b = new buyer();
                            b.Name = it.Current.Value;
                            comboBox3.Items.Add(b);
                        }
                    }
                }
            }

        }

        private void button11_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "XML|*.xml";
            if (saveFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            // получаем выбранный файл
            string filename = saveFileDialog1.FileName;

            if (!File.Exists(filename))
            {
                MessageBox.Show("Файла чека не существует.Файл успешно создан в каталоге Debug", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                FileStream fs1 = File.Create(filename);
                fs1.Close();
                xml_ChangedChek(sender, e, filename);
            }
            else
            {
                var res = MessageBox.Show("Заменить существующий файл чека?", "Инфо", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (DialogResult.Yes == res)
                {
                    xml_ChangedChek(sender, e, filename);
                }
            }

        }

        private void xml_ChangedChek(object sender, EventArgs p1, string filename)
        {
            if (comboBox1.SelectedIndex != -1 && comboBox3.SelectedIndex != -1 && listBox1.Items.Count != 0)
            {
                XmlTextWriter check = null;
                try
                {
                    check = new XmlTextWriter(filename, System.Text.Encoding.Unicode);
                    check.Formatting = Formatting.Indented;
                    check.WriteStartDocument();
                    check.WriteStartElement("CheckList");

                    check.WriteStartElement($"date");
                    check.WriteElementString($"date", Convert.ToString(DateTime.Now));
                    check.WriteEndElement();

                    b = (buyer)comboBox3.Items[comboBox3.SelectedIndex];
                    //buyer b2 = new buyer(b);
                    check.WriteStartElement($"buyer");
                    check.WriteElementString($"buyer", Convert.ToString(b));
                    check.WriteEndElement();

                    u = (user)comboBox1.Items[comboBox1.SelectedIndex];
                    check.WriteStartElement($"user");
                    check.WriteElementString($"user", Convert.ToString(u));
                    check.WriteEndElement();

                    for (var i = 0; i < listBox1.Items.Count; i++)
                    {
                        t = (Tovar)listBox1.Items[i];
                        check.WriteStartElement($"tovar");
                        check.WriteElementString($"tovar{i}", t.ToString());
                        check.WriteEndElement();
                    }
                    check.WriteEndElement();
                }
                finally
                {
                    if (check != null)
                        check.Close();
                    MessageBox.Show("Данные внесены в файл", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                if (listBox1.Items.Count == 0)
                {
                    MessageBox.Show("список покупок пуст, чек не оформлен", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("combobox продавца или покупателя пуст, чек не оформлен", "Инфо", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
    }
}
