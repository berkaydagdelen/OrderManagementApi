namespace OrderManagementApi.DTO.User.Request
{
    public class UserSaveRequest
    {
        public string Name { get; set; }
        public string Surname { get; set; }

        public string Email { get; set; }
        public string? Username { get; set; }

        public string? Password { get; set; }
    }
} 