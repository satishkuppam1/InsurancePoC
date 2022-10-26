namespace UserService.Dtos
{
    public class LoginDto
    {
        public int UserId { get; set; }
        public string Role { get; set; }
        public bool IsSuccesful { get; set; }
    }
}