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
    public partial class CostCategoryForm : Form
    {
        DatabaseContext context = new DatabaseContext();
        public CostCategoryForm()
        {
            InitializeComponent();
        }

        private void menuStrip2_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddCategoryForm addCategoryForm = new AddCategoryForm();
            addCategoryForm.ShowDialog();
            if (addCategoryForm.DialogResult == DialogResult.OK)
            {
                RefreshGrid();
            }
        }
        private void RefreshGrid()
        {
            context = new DatabaseContext();
            costCategoryBindingSource.DataSource = context.CostCategory.ToList();
        }

        private void CostCategotyForm_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                DialogResult dr = MessageBox.Show("Are you sure to delete this category?",
                      "Deletion", MessageBoxButtons.YesNo);

                if (dr == DialogResult.Yes)
                {
                    try
                    {

                        var idToRemove = (int)dataGridView1.CurrentRow.Cells[0].Value;
                        var categoryToDelete = context.CostCategory.Where(x => x.Id == idToRemove).First();
                        context.CostCategory.Remove(categoryToDelete);
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
                EditCategoryForm editCategoryForm = new EditCategoryForm(categoryId);
                editCategoryForm.ShowDialog();
                if (editCategoryForm.DialogResult == DialogResult.OK)
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
