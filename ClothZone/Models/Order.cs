namespace ClothZone.Models
{
    public class Order
    {
        public int Id { get; set; }
        public long TAmount { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
