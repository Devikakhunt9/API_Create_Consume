using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class UserModel
    {
        public int UserId { get; set; }
        [Required]
        public string? UserName { get; set; }
        [Required]
        public string? UserEmail { get; set; }
        [Required]
        public string? UserContact { get; set; }

    }
}
