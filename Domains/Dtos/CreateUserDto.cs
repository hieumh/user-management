using System.ComponentModel.DataAnnotations;

namespace UserManagement.Domains.Dtos
{
    public class CreateUserDto : BaseUser
    {
        [Required(ErrorMessage = "Birth is required")]
        public DateTime Birth { get; set; }

        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string? Email { get; set; }
    }
}