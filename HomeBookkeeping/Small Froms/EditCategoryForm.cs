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
    public partial class EditCategoryForm : Form
    {
        DatabaseContext context = new DatabaseContext();
        int caterogyId;
        CostCategory category;
        public EditCategoryForm(int id)
        {
            caterogyId=id;
            InitializeComponent();
        }
        public EditCategoryForm()
        {
            InitializeComponent();
        }

        private void EditCategoryForm_Load(object sender, EventArgs e)
        {
            category = context.CostCategory.Where(x => x.Id == caterogyId).First();
            textBox1.Text = category.CategoryName;
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
            if ((string.IsNullOrEmpty(textBox1.Text) != true) && (textBox1.Text.Length <= 60))
            {
                category.CategoryName = textBox1.Text;
            }
            else
            {
                MessageBox.Show("Incorrect input!");
                return;
            }          
            var categoryExpenses=context.Expenses.Where(x=>x.CategoryId==category.Id).ToList();
            for(int i=0;i<categoryExpenses.Count;i++)
            {
                categoryExpenses[i].Name = category.CategoryName;
            }
            context.SaveChanges();
            DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
