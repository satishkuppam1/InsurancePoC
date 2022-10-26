namespace UserService.Model
{
    public class CartItem
    {
        public int ItemId { get; set; }
        public int CartId { get; set; }
        public int UserId { get; set; }
        public System.DateTime DateCreated { get; set; }
        public int PolicyId { get; set; }
    }
}