using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinShark.Models
{
    public class Stock
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(7)]
        [Required]
        public string? Symbol { get; set; } = string.Empty;
        //[RegularExpression("^[a-zA-Z0-9 ]+$")]
        public string? CompanyName { get; set; }
        [Column(TypeName = "decimal(18,2)")]
        public decimal Purchase { get; set; }
        public DateTime LastDiv { get; set; }
        public string Industry { get; set; }
        public decimal MarketCap { get; set; }
        public ICollection<Comment> Comments { get; set; }

    }
}
