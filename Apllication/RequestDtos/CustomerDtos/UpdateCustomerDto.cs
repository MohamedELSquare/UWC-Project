namespace Apllication.RequestDtos.CustomerDtos
{
    public class UpdateCustomerDto
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public string? Location { get; set; }

        public string? Contract { get; set; }
    }
}
