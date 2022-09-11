using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBookkeeping.Models
{
    public class TableBuilder
    {
       
        
        public static DataTable MakeTable(int year)
        {
            DatabaseContext context = new DatabaseContext();
            int thisYear = year;
            List<string> category = new List<string>();
            var expenses = context.Expenses.ToList();
            var categorys = context.CostCategory.ToList();

            for (int i = 0; i < categorys.Count; i++)
            {
                category.Add(categorys[i].CategoryName);
            }

            DataTable table = new DataTable();
            table.Columns.Add("Month", typeof(string));
            string[] month = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December" };
            for (int i = 0; i < month.Length; i++)
            {
                table.Rows.Add(month[i]);
            }
            for (int i = 0; i < categorys.Count; i++)
            {
                table.Columns.Add(categorys[i].CategoryName, typeof(decimal));
            }
            for (int i = 0; i < categorys.Count; i++)
            {
                decimal month1 = 0; decimal month2 = 0; decimal month3 = 0; decimal month4 = 0; decimal month5 = 0; decimal month6 = 0;
                decimal month7 = 0; decimal month8 = 0; decimal month9 = 0; decimal month10 = 0; decimal month11 = 0; decimal month12 = 0;
                for (int j = 0; j < expenses.Count; j++)
                {
                    if ((expenses[j].Date.Year == thisYear) && (expenses[j].Date.Month == 1) && (expenses[j].Name == categorys[i].CategoryName))
                    {
                        month1 += expenses[j].Price;
                        table.Rows[0][categorys[i].CategoryName] = month1;
                    }
                    if ((expenses[j].Date.Year == thisYear) && (expenses[j].Date.Month == 2) && (expenses[j].Name == categorys[i].CategoryName))
                    {
                        month2 += expenses[j].Price;
                        table.Rows[1][categorys[i].CategoryName] = month2;
                    }
                    if ((expenses[j].Date.Year == thisYear) && (expenses[j].Date.Month == 3) && (expenses[j].Name == categorys[i].CategoryName))
                    {
                        month3 += expenses[j].Price;
                        table.Rows[2][categorys[i].CategoryName] = month3;
                    }
                    if ((expenses[j].Date.Year == thisYear) && (expenses[j].Date.Month == 4) && (expenses[j].Name == categorys[i].CategoryName))
                    {
                        month4 += expenses[j].Price;
                        table.Rows[3][categorys[i].CategoryName] = month4;
                    }
                    if ((expenses[j].Date.Year == thisYear) && (expenses[j].Date.Month == 5) && (expenses[j].Name == categorys[i].CategoryName))
                    {
                        month5 += expenses[j].Price;
                        table.Rows[4][categorys[i].CategoryName] = month5;
                    }
                    if ((expenses[j].Date.Year == thisYear) && (expenses[j].Date.Month == 6) && (expenses[j].Name == categorys[i].CategoryName))
                    {
                        month6 += expenses[j].Price;
                        table.Rows[5][categorys[i].CategoryName] = month6;
                    }
                    if ((expenses[j].Date.Year == thisYear) && (expenses[j].Date.Month == 7) && (expenses[j].Name == categorys[i].CategoryName))
                    {
                        month7 += expenses[j].Price;
                        table.Rows[6][categorys[i].CategoryName] = month7;
                    }
                    if ((expenses[j].Date.Year == thisYear) && (expenses[j].Date.Month == 8) && (expenses[j].Name == categorys[i].CategoryName))
                    {
                        month8 += expenses[j].Price;
                        table.Rows[7][categorys[i].CategoryName] = month8;
                    }
                    if ((expenses[j].Date.Year == thisYear) && (expenses[j].Date.Month == 9) && (expenses[j].Name == categorys[i].CategoryName))
                    {
                        month9 += expenses[j].Price;
                        table.Rows[8][categorys[i].CategoryName] = month9;
                    }
                    if ((expenses[j].Date.Year == thisYear) && (expenses[j].Date.Month == 10) && (expenses[j].Name == categorys[i].CategoryName))
                    {
                        month10 += expenses[j].Price;
                        table.Rows[9][categorys[i].CategoryName] = month10;
                    }
                    if ((expenses[j].Date.Year == thisYear) && (expenses[j].Date.Month == 11) && (expenses[j].Name == categorys[i].CategoryName))
                    {
                        month11 += expenses[j].Price;
                        table.Rows[10][categorys[i].CategoryName] = month11;
                    }
                    if ((expenses[j].Date.Year == thisYear) && (expenses[j].Date.Month == 12) && (expenses[j].Name == categorys[i].CategoryName))
                    {
                        month12 += expenses[j].Price;
                        table.Rows[11][categorys[i].CategoryName] = month12;
                    }
                }
            }
            return table;

        }
    }
}
