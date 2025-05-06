using System.ComponentModel.DataAnnotations;

namespace Apllication.RequestDtos.SubCustomerDtos
{
    public class UpdateSubCustomerDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string? Location { get; set; }

        [Required]
        public int DCustomerId { get; set; }
    }
}
