﻿using System;
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
    public partial class Form3 : Form
    {
        private ProductExamEntities2 db;
        private Attribute t;
        private Value value;

        public Form3(ProductExamEntities2 db)
        {
            InitializeComponent();
            this.db = db;
            GetAllProduct();
        }

        private void GetAllProduct()
        {
            var au = db.Attribute.ToList();
            foreach (var VARIABLE in au)
            {
                listBox1.Items.Add(VARIABLE.NameAtt);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            t = new Attribute();
            var tm = db.Attribute;
            if (tm.Count() == 0)
            {
                t.Id = 1;
            }
            else
            {
                t.Id = db.Attribute.Max(x => x.Id) + 1;
            }


            Form4 addform = new Form4(t, true);
            if (addform.ShowDialog() == DialogResult.OK)
            {
                var attribute = db.Attribute;
                attribute.Add(t);
                var product = db.Product;
                var valueTable = db.Value;
                foreach (var VARIABLE in product)
                {
                    value = new Value();
                    value.IdProduct = VARIABLE.Id;
                    value.IdAttribute = t.Id;
                    valueTable.Add(value);
                }
                db.SaveChanges();
                listBox1.Items.Clear();
                GetAllProduct();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Вы не выбрали итем"); return;
            }
            t = new Attribute();
            int n = listBox1.SelectedIndex;
            var au = db.Attribute.OrderBy(x => x.Id);
            foreach (var VARIABLE in au.Skip(n))
            {
                t = VARIABLE;
                break;
            }
            Form4 editform = new Form4(t, false);
            editform.ShowDialog();
            listBox1.Items.RemoveAt(n);
            listBox1.Items.Insert(n, t);
            listBox1.SelectedIndex = n;
            db.SaveChanges();
            listBox1.Items.Clear();
            GetAllProduct();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex == -1)
            {
                MessageBox.Show("Вы не выбрали итем"); return;
            }
            t = new Attribute();
            int n = listBox1.SelectedIndex;
            var au = db.Attribute.OrderBy(x => x.Id);
            foreach (var VARIABLE in au.Skip(n))
            {
                t = VARIABLE;
                break;
            }
            var valueTable = db.Value;
            foreach (var VARIABLE in valueTable)
            {
                if (VARIABLE.IdAttribute==t.Id)
                {
                    db.Value.Remove(VARIABLE);
                }
            }
            db.Attribute.Remove(t);
            listBox1.Items.RemoveAt(n);
            db.SaveChanges();
            listBox1.Items.Clear();
            GetAllProduct();
        }
    }
}
