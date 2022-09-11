using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeBookkeeping.Models
{
    public class Expenses
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Сomment { get; set; }

        [ForeignKey("CostCategory")]
        public int CategoryId { get; set; } 
        public CostCategory CostCategory { get; set; }

    }
}
