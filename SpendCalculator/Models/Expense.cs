using System.ComponentModel.DataAnnotations;

namespace SpendCalculator.Models
{
    public class Expense
    {
        public int Id { get; set; }

        public decimal Number { get; set; }

        [Required]
        public string? ExpenseName { get; set; }
    }
}
