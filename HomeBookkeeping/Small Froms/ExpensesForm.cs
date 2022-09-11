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
    public partial class ExpensesForm : Form
    {
        DatabaseContext context = new DatabaseContext();
        public ExpensesForm()
        {
            InitializeComponent();
        }

        private void ExpensesForm_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }
        private void RefreshGrid()
        {
            context = new DatabaseContext();
            expensesBindingSource.DataSource = context.Expenses.ToList();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (context.CostCategory.FirstOrDefault() != null)
            {
                AddExpensesForm addExpensesForm = new AddExpensesForm();
                addExpensesForm.ShowDialog();
                if (addExpensesForm.DialogResult == DialogResult.OK)
                {
                    RefreshGrid();
                }
            }
            else
            {
                MessageBox.Show("You must add cost category first!");
                return;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (dateTimePicker1.Value >= dateTimePicker2.Value)
            {
                MessageBox.Show("Incorrect time period!");
                return;
            }
            else
            {
                context = new DatabaseContext();
                expensesBindingSource.DataSource = context.Expenses.Where(x => (x.Date >= dateTimePicker1.Value) && (x.Date <= dateTimePicker2.Value)).ToList();

            }
        }


        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (dataGridView1.CurrentRow != null)
            {
                DialogResult dr = MessageBox.Show("Are you sure to delete this expense?",
                          "Deletion", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    try
                    {
                        var idToRemove = (int)dataGridView1.CurrentRow.Cells[0].Value;
                        var expenseToDelete = context.Expenses.Where(x => x.Id == idToRemove).First();
                        context.Expenses.Remove(expenseToDelete);
                        context.SaveChanges();
                        RefreshGrid();

                    }
                    catch (Exception ex)
                    {
                        /// todo: log exception
                        MessageBox.Show(ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("There is nothing to delete!");
                return;
            }

        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                var categoryId = (int)dataGridView1.CurrentRow.Cells[0].Value;
                EditExpensesForm editExpensesForm = new EditExpensesForm(categoryId);
                editExpensesForm.ShowDialog();
                if (editExpensesForm.DialogResult == DialogResult.OK)
                {
                    RefreshGrid();
                }
            }
            else
            {
                MessageBox.Show("There is nothing to edit!");
                return;
            }
        }
    }
}
