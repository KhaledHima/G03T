using System.ComponentModel.DataAnnotations.Schema;

namespace FinShark.Models
{
    public class Wallet
    {
        public int Id { get; set; }
        public AppUser? AppUser { get; set; }

        [ForeignKey(nameof(AppUserId))]
        public int AppUserId { get; set; }

        public Stock? Stock { get; set; }
        [ForeignKey(nameof(StockId))]

        public int StockId { get; set; }

        public int Quantity { get; set; }
    }
}
