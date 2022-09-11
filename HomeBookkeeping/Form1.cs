using HomeBookkeeping.Small_Froms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HomeBookkeeping
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void costCategoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CostCategoryForm costCategotyForm = new CostCategoryForm();
            costCategotyForm.ShowDialog();
        }

        private void expensesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExpensesForm expensesForm = new ExpensesForm();
            expensesForm.ShowDialog();
        }

        private void statisticsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StatisticsForm statisticsForm = new StatisticsForm();
            statisticsForm.ShowDialog();
        }
    }
}
