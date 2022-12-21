using System.ComponentModel.DataAnnotations;

namespace FirstApiRepPertten.Models
{
    public class User
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Please Enter Your Name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please Enter Your Address")]
        public string Address { get; set; }
        [Required(ErrorMessage = "Please Enter Your PhoneNumber")]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Please Enter Your Email")]

        public string Email { get; set; }
    }
}
