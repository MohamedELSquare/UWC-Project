namespace Apllication.ResponseDtos.CustomerDtos
{
    public class GetCustomerDto
    {
        public int Id { get; set; }
        public string? CustomerName { get; set; }

        public List<string> Warehouses { get; set; }

        public string? Location { get; set; }

        public string? Contract { get; set; }
    }
}
