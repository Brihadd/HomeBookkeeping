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
    public partial class AddCategoryForm : Form
    {
        DatabaseContext context = new DatabaseContext();
        public AddCategoryForm()
        {
            InitializeComponent();
        }

        private void AddCategoryForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            CostCategory costCategory = new CostCategory();
            if ((string.IsNullOrEmpty(textBox1.Text) != true)&&(textBox1.Text.Length<=60))
            {
                costCategory.CategoryName = textBox1.Text;
            }
            else
            {
                MessageBox.Show("Incorrect input!");
                return;
            }

            context.CostCategory.Add(costCategory);
            context.SaveChanges();
            DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}
