using System.ComponentModel.DataAnnotations;

namespace MoneyTrack.Models
{
    public class Expense
    {
        public int Id { get; set; }
        public decimal Value { get; set; }
        
        [Required] 
        public string? Description { get; set; }
    }
}
