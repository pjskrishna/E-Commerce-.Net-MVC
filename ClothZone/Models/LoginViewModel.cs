using System.ComponentModel.DataAnnotations;

namespace ClothZone.Models
{
    public class LoginViewModel
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Display(Name ="Remember me")]
        public bool IsRemember { get; set; }    

    }
}
