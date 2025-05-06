namespace Apllication.ResponseDtos.CustomerDtos
{
    public class GetCustomerListDto
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public List<string> Warehouses { get; set; }

        public string? Location { get; set; }

        public string? Contract { get; set; }
    }



}
