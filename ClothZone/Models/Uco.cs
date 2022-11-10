namespace ClothZone.Models
{
    public class Uco
    {
        public int Id { get; set; }
        public int Uid { get; set; }
        public int Cid { get; set; }
        public int Oid { get; set; }
        public User User { get; set; }
        public Cart Cart { get; set; }
        public Order Order { get; set; }
    }
}
