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
    public partial class EditExpensesForm : Form
    {
        DatabaseContext context = new DatabaseContext();
        int expensesId;
        Expenses expense;
        public EditExpensesForm(int id)
        {
            expensesId = id;
            InitializeComponent();
        }

        private void EditExpensesForm_Load(object sender, EventArgs e)
        {
            costCategoryBindingSource.DataSource = context.CostCategory.ToList();
            expense = context.Expenses.Where(x => x.Id == expensesId).First();
            dateTimePicker1.Value = expense.Date;
            comboBox1.SelectedItem = expense.CostCategory;
            textBox1.Text=expense.Price.ToString();
            richTextBox1.Text = expense.Сomment;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            expense.CostCategory = (CostCategory)comboBox1.SelectedItem;
            decimal number;
            bool success = decimal.TryParse(textBox1.Text, out number);
            if (success)
            {
                if (number > 0)
                {
                    expense.Price = number;
                }
            }
            else
            {
                MessageBox.Show("Incorrect cost!");
                return;
            }
            expense.Name = comboBox1.Text.ToString();
            expense.Сomment = richTextBox1.Text;
            expense.Date = dateTimePicker1.Value.Date;
            context.SaveChanges();
            DialogResult = DialogResult.OK;
            this.Close();
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }
    }
}
