using Microsoft.EntityFrameworkCore;

namespace MoneyTrack.Models
{
    public class ExpensesDB : DbContext

    {
        public DbSet<Expense> Expenses { get; set; }

        public ExpensesDB(DbContextOptions<ExpensesDB>options)
        : base(options)
        {
        }
     
    }
}
