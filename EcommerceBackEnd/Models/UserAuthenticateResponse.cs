namespace EcommerceBackEnd.Models
{
    public class UserAuthenticateRequest
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
    public class UserAuthenticateResponse
    {
        public string Email { get; set; }
        public string Token { get; set; }

        public string Role { get; set; }
    }
}
