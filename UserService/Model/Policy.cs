namespace UserService.Model
{
    public class Policy
    {
        public int PoliyId { get; set; }
        public string PolicyName { get; set; }
        public string PolicyType { get; set; }
        public string Insurer { get; set; }
        public decimal Premium { get; set; }
    }
}