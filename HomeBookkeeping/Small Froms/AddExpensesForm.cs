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
    public partial class AddExpensesForm : Form
    {
        DatabaseContext context = new DatabaseContext();
        public AddExpensesForm()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            char number = e.KeyChar;
            if (!Char.IsDigit(number) && number != 8 && number != 44)
            {
                e.Handled = true;
            }
        }

        private void AddExpensesForm_Load(object sender, EventArgs e)
        {
            costCategoryBindingSource1.DataSource = context.CostCategory.ToList();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Expenses expense = new Expenses();
            decimal number;
            expense.CostCategory = (CostCategory)comboBox1.SelectedItem;
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
            expense.Price =decimal.Parse(textBox1.Text);
            context.Expenses.Add(expense);
            context.SaveChanges();
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
