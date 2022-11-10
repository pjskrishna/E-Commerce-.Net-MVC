using System.ComponentModel.DataAnnotations.Schema;

namespace ClothZone.Models
{
    public class Cart
    {
        public int Id { get; set; }
        public int ProductId { get; set; }
        public int UserId { get; set; }
        [Column(TypeName ="decimal(8,2)")]
        public decimal Qty { get; set; }
        public long TPrice { get; set; }
        public User User { get; set; }
        
     }
}
