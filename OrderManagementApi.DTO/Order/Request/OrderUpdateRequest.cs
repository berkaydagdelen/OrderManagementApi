namespace OrderManagementApi.DTO.BedType.Request
{
    public class OrderUpdateRequest
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }

    }
}
