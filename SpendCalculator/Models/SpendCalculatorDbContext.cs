using Microsoft.EntityFrameworkCore;

namespace SpendCalculator.Models
{
    public class SpendCalculatorDbContext : DbContext
    {
        public DbSet<Expense> Expenses { get; set; }

        public SpendCalculatorDbContext(DbContextOptions options) 
            : base(options)
        {

        }
    }
}
