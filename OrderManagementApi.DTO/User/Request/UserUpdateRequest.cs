namespace OrderManagementApi.DTO.User.Request
{
    public class UserUpdateRequest
    {
        public int Id { get; set; }

        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string? Username { get; set; }
        public string? Password { get; set; }
    }
}