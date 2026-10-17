using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FinShark.Models
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public Stock Stock { get; set; }
        [ForeignKey(nameof(StockId))]
        public int StockId { get; set; }

    }
}
