using HomeBookkeeping.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeBookkeeping.Small_Froms
{
    public partial class StatisticsForm : Form
    {
        DatabaseContext context = new DatabaseContext();
        int thisYear;
        List<Expenses> expenses;
        List<CostCategory> categorys;

        public StatisticsForm()
        {
            InitializeComponent();
        }

        private void StatisticsForm_Load(object sender, EventArgs e)
        {
            List<int> years = new List<int>();
            expenses = context.Expenses.ToList();
            for (int i = 0; i < expenses.Count; i++)
            {
                if (!years.Contains(expenses[i].Date.Year)) years.Add(expenses[i].Date.Year);

            }
            comboBox1.DataSource = years;
            thisYear = int.Parse(comboBox1.Text);
            var table = TableBuilder.MakeTable(thisYear);
            dataGridView1.DataSource = table;
        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            thisYear = int.Parse(comboBox1.Text);
            var table = TableBuilder.MakeTable(thisYear);
            dataGridView1.DataSource = table;
        }


        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            var categorys = context.CostCategory.ToList();
            if (checkBox1.Checked == true)
            {
                for (int i = 1; i <= categorys.Count; i++)
                {
                    int counter = 0;
                    for (int j = 0; j < 12; j++)
                    {
                        if (dataGridView1[i, j].Value.ToString() == "") counter++;
                        if (counter == 12) dataGridView1.Columns[i].Visible = false;
                    }
                }
            }
            else
            {
                for (int i = 1; i <= categorys.Count; i++)
                {
                    dataGridView1.Columns[i].Visible = true;
                }
            }
        }
    }
}
