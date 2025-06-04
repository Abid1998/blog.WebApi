namespace blog.Core.DTOs.AccountDtos
{
    public class RegisterDto
    {
        public string? FullName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }

        // Optional: Phone number for identity confirmation
        public string? PhoneNumber { get; set; }

        // Optional: List of role names to assign to user
        public List<string>? Roles { get; set; }

        // Optional: List of claims (e.g., claim type and value pairs)
        public List<ClaimDto>? Claims { get; set; }

    }
}
