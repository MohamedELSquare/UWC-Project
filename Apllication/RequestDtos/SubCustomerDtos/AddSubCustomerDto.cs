using System.ComponentModel.DataAnnotations;

namespace Apllication.RequestDtos.SubCustomerDtos
{
    public class AddSubCustomerDto
    {
        [Required]
        public string Name { get; set; }

        public string? Location { get; set; }

        [Required]
        public int DCustomerId { get; set; }
    }
}
