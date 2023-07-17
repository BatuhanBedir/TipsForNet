namespace Record.Dtos
{
    public class LoginDto
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
    public record LoginDtoRecord(
        string Email,
        string Password,
        bool RememberMe=true);
}
